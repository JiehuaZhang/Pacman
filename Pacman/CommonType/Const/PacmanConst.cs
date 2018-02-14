using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CommonType.Const
{
    public class PacmanConst
    {
        public const string SQLTableName = "Pacmans";
        public const string SQLCreatePacmanTalbeQuery = @"CREATE TABLE IF NOT EXISTS  Pacmans(
                                                          ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                                          Points TEXT   NULL,
                                                          Strategy TEXT  NULL,
                                                          Weight INTEGER  NULL,
                                                          Generation INTEGER  NULL,
                                                          AveragePoints INTEGER  NULL,
                                                          MaxPoints INTEGER NULL,
                                                          PositivePointsCount INTEGER NULL)";

        public const string SQLInsertPacman = @"INSERT INTO Pacmans (Points,Strategy,Weight,Generation, AveragePoints,MaxPoints,PositivePointsCount ) Values ";
        public const string SQLGetLastGenerationQuery = @"SELECT Max(Generation) AS LastGeneration FROM pacmans ";
        public const string SQLGetOneGenerationPacmansQuery = @"Select * from pacmans where generation = ";
        public const string SQLCreateReportQuery = @"CREATE TABLE IF NOT EXISTS  Report(
                                                          ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                                          Generation INTEGER   NULL,
                                                          MaxAveragePoints INTEGER  NULL,
                                                          MinAveragePoints INTEGER  NULL,
                                                          MaxPointsOfFirst INTEGER  NULL,
                                                          CountPositivePointsOfFirst INTEGER  NULL,
                                                          MaxPoints NVARCHAR(100) NULL,
                                                          MaxCountPositivePoints NVARCHAR(100) NULL)";
        public const string SQLInsertReport = @"INSERT INTO Report(Generation,MaxAveragePoints,
                                                                        MinAveragePoints,MaxPointsOfFirst,
                                                                        CountPositivePointsOfFirst,MaxPoints,MaxCountPositivePoints) Values ";
        public const string SQLGetLastGenerationOfReportQuery = @"SELECT Max(Generation) AS LastGeneration FROM Report ";
        public const string SQLReportTableName = "Report";
    }
}
