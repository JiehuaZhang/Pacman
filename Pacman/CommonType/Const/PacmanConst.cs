using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonType.Const
{
    public class PacmanConst
    {
        public const string SQLDatabaseName = "database.db";
        public const string SQLTableName = "Pacmans";
        public const string SQLCreatePacmanTalbeQuery = @"CREATE TABLE IF NOT EXISTS [Pacmans] (
                                                          [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                                          [Points] NVARCHAR(2048)  NULL,
                                                          [Strategy] VARCHAR(2048)  NULL,
                                                          [Ranking] INTEGER NULL,
                                                          [Weight] INTEGER NULL,
                                                          [Generation] INTEGER NULL,
                                                          [AveragePoints] INTEGER NULL";

        public const string SQLInsertPacman = @"INSERT INTO Pacmans (Points,Strategy, Ranking,Weight,Generation, AveragePoints) Values ";
    }
}
