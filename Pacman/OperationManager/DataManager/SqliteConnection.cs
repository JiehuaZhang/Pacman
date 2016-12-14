using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonType;
using CommonType.Const;
using OperationManager.Helper;

namespace OperationManager.DataManager
{
    public class SqLiteConnection
    {
        public bool IfTableExist()
        {
            var res = true;
            if (File.Exists(PacmanConst.SQLDatabaseName))
            {
                using (var con = new SQLiteConnection("data source=" + PacmanConst.SQLDatabaseName))
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
                SQLiteConnection.CreateFile(PacmanConst.SQLDatabaseName);
                using (var con = new SQLiteConnection("data source=" + PacmanConst.SQLDatabaseName))
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

        public void InsertConnection(List<string> insertValueQuery)
        {

            using (var con = new SQLiteConnection("data source=" + PacmanConst.SQLDatabaseName))
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

        public int GetLastGeneration()
        {
            var generation = 0;
            using (var con = new SQLiteConnection("data source=" + PacmanConst.SQLDatabaseName))
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
            using (var con = new SQLiteConnection("data source=" + PacmanConst.SQLDatabaseName))
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
                            pacman.Strategy = StringHelper.ConvertStringToStarategy(reader["Strategy"].ToString());
                            pacman.Weight = Convert.ToInt32(reader["Weight"]);
                            pacman.Generation = Convert.ToInt32(reader["Generation"]);
                            pacmanList.Add(pacman);
                        }
                    }
                    con.Close();
                }
            }
            return pacmanList;
        }
    }
}
