using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.IO;
using CommonType;
using CommonType.Const;
using OperationManager.Helper;

namespace OperationManager.DataManager
{
    public class SqLiteConnection : ISqLiteConnection
    {
        //private readonly string SQLDatabaseName = ConfigurationManager.AppSettings["DatabaseName"];
        private readonly string SQLDatabaseName = "databaseNew.db";
        public bool IfTableExist()
        {
            bool res;
            if (File.Exists(SQLDatabaseName))
            {
                using (var con = new SQLiteConnection("data source=" + SQLDatabaseName))
                {
                    using (SQLiteCommand com = new SQLiteCommand(con))
                    {
                        con.Open();
                        com.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='" +
                                          PacmanConst.SQLTableName + "';";
                        using (SQLiteDataReader reader = com.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                res = true;
                            }
                            else
                            {
                                res = false;
                            }
                        }
                        if (!res)
                        {
                            com.CommandText = PacmanConst.SQLCreatePacmanTalbeQuery;
                            com.ExecuteNonQuery();
                        }
                        con.Close();
                    }
                }
            }
            else
            {
                res = false;
                SQLiteConnection.CreateFile(SQLDatabaseName);
                using (var con = new SQLiteConnection("data source=" + SQLDatabaseName))
                {
                    using (var com = new SQLiteCommand(con))
                    {
                        con.Open();
                        com.CommandText = PacmanConst.SQLCreatePacmanTalbeQuery;
                        com.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            return res;
        }

        public void CheckIfNeedToCreateReportTable()
        {
            var result = true;
            using (var con = new SQLiteConnection("data source=" + SQLDatabaseName))
            {
                using (var com = new SQLiteCommand(con))
                {

                    con.Open();
                    com.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='" +
                                      PacmanConst.SQLReportTableName + "';";
                    using (SQLiteDataReader reader = com.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result = false;
                        }
                    }
                    if (result)
                    {
                        com.CommandText = PacmanConst.SQLCreateReportQuery;
                        com.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
        }

        public bool CheckIfNeedToDoReport(int pacmanLastGeneration, ref int reportGeneration)
        {
            using (var con = new SQLiteConnection("data source=" + SQLDatabaseName))
            {
                using (var com = new SQLiteCommand(con))
                {
                    con.Open();
                    com.CommandText = PacmanConst.SQLGetLastGenerationOfReportQuery;
                    using (var reader = com.ExecuteReader())
                    {
                        if (reader.Read() && reader["LastGeneration"]!=DBNull.Value)
                        {
                            reportGeneration = Convert.ToInt32(reader["LastGeneration"]);
                        }
                    }
                    con.Close();
                }
            }
            return pacmanLastGeneration > reportGeneration;
        }


        public void InsertConnection(List<string> insertValueQuery)
        {

            using (var con = new SQLiteConnection("data source=" + SQLDatabaseName))
            {
                using (var com = new SQLiteCommand(con))
                {
                    con.Open();
                    foreach (var value in insertValueQuery)
                    {
                        com.CommandText =PacmanConst.SQLInsertPacman + value;
                        com.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
        }

        public void InsertReport(List<Report> reports)
        {
            using (var con = new SQLiteConnection("data source=" + SQLDatabaseName))
            {
                using (var com = new SQLiteCommand(con))
                {
                    con.Open();
                    foreach (var report in reports)
                    {
                        com.CommandText = PacmanConst.SQLInsertReport + $"('{report.Generation}','{report.MaxAveragePoints}', '{report.MinAveragePoints}', '{report.MaxPointsOfFirst}', '{report.CountPositivePointsOfFirst}', '{report.MaxPoints}//{report.MaxPointsAveragePoints}', '{report.MaxCountPositivePoints}//{report.MaxCountPositivePointsAveragePoints}')";
                        com.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
        }

        public int GetLastGeneration()
        {
            var generation = 0;
            using (var con = new SQLiteConnection("data source=" + SQLDatabaseName))
            {
                using (var com = new SQLiteCommand(con))
                {
                    con.Open();
                    com.CommandText = PacmanConst.SQLGetLastGenerationQuery;
                    using (SQLiteDataReader reader = com.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            generation = Convert.ToInt32(reader["LastGeneration"]);
                        }
                    }
                    con.Close();
                }
            }
            return generation;
        }

        public List<Pacman> GetOneGenerationPacmans(int generation)
        {
            var pacmanList = new List<Pacman>();
            using (var con = new SQLiteConnection("data source=" + SQLDatabaseName))
            {
                using (var com = new SQLiteCommand(con))
                {
                    con.Open();
                    com.CommandText = PacmanConst.SQLGetOneGenerationPacmansQuery + generation;
                    using (SQLiteDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var pacman = new Pacman();
                            pacman.ID = Convert.ToInt32(reader["ID"]);
                            pacman.Strategy = StringHelper.ConvertStringToStarategy(reader["Strategy"].ToString());
                            pacman.Weight = Convert.ToInt32(reader["Weight"]);
                            pacman.Generation = Convert.ToInt32(reader["Generation"]);
                            pacman.PointsString = reader["Points"].ToString();
                            pacman.AveragePoints = Convert.ToInt32(reader["AveragePoints"]);
                            if(reader["MaxPoints"]!=DBNull.Value)
                            pacman.MaxPoints = Convert.ToInt32(reader["MaxPoints"]);
                            if(reader["PositivePointsCount"]!= DBNull.Value)
                            pacman.PositivePointsCount = Convert.ToInt32(reader["PositivePointsCount"]);
                            pacmanList.Add(pacman);
                        }
                    }
                    con.Close();
                }
            }
            return pacmanList;
        }

        public string GetOneStrategy()
        {
            var strategy = string.Empty;
            using (var con = new SQLiteConnection("data source=" + SQLDatabaseName))
            {
                using (var com = new SQLiteCommand(con))
                {
                    con.Open();
                    com.CommandText = "SELECT  Strategy FROM pacmans WHERE ID= 2695";
                    using (SQLiteDataReader reader = com.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            strategy = reader["Strategy"].ToString();
                        }
                    }
                    con.Close();
                }
            }
            return strategy;
        }

        public void UpdatePacmansMaxPoints(Pacman p)
        {
            using (var con = new SQLiteConnection("data source=" + SQLDatabaseName))
            {
                using (var com = new SQLiteCommand(con))
                {
                    con.Open();
                    com.CommandText = "Update Pacmans Set MaxPoints =" + p.MaxPoints + "," + "PositivePointsCount =" +
                                      p.PositivePointsCount +" Where ID="+p.ID;
                    com.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public void UpdateWeight(Pacman p)
        {
            using (var con = new SQLiteConnection("data source=" + SQLDatabaseName))
            {
                using (var com = new SQLiteCommand(con))
                {
                    con.Open();
                    com.CommandText = "Update Pacmans Set Weight =" + p.Weight + " Where ID=" + p.ID;
                    com.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}
