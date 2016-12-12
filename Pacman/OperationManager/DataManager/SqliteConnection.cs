using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonType.Const;

namespace OperationManager.DataManager
{
    public class SqLiteConnection
    {
        public bool CheckIsNewStart()
        {
            var res = true;
            if (File.Exists(PacmanConst.SQLDatabaseName))
            {
                using (var con = new System.Data.SQLite.SQLiteConnection("data source=" + PacmanConst.SQLDatabaseName))
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
                                res = false;
                            }
                        }
                        if (res)
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
                System.Data.SQLite.SQLiteConnection.CreateFile(PacmanConst.SQLDatabaseName);
                using (var con = new System.Data.SQLite.SQLiteConnection("data source=" + PacmanConst.SQLDatabaseName))
                {
                    using (SQLiteCommand com = new SQLiteCommand(con))
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

            using (var con = new System.Data.SQLite.SQLiteConnection("data source=" + PacmanConst.SQLDatabaseName))
            {
                using (SQLiteCommand com = new SQLiteCommand(con))
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
    }
}
