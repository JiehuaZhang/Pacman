using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CommonType.Const
{
    public class PacmanConst
    {
        public const string SQLDatabaseName = "database.db";
        public const string SQLTableName = "Pacmans";
        public const string SQLCreatePacmanTalbeQuery = @"CREATE TABLE IF NOT EXISTS  Pacmans(
                                                          ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                                          Points TEXT   NULL,
                                                          Strategy TEXT  NULL,
                                                          Weight INTEGER  NULL,
                                                          Generation INTEGER  NULL,
                                                          AveragePoints INTEGER  NULL)";

        public const string SQLInsertPacman = @"INSERT INTO Pacmans (Points,Strategy,Weight,Generation, AveragePoints) Values ";
        public const string SQLGetLastGenerationQuery = @"SELECT Max(Generation) AS LastGeneration FROM pacmans ";
        public const string SQLGetOneGenerationPacmansQuery = @"Select * from pacmans where generation = ";
    }
}
