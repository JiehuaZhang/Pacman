using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonType;
using OperationManager.DataManager;
using OperationManager.Helper;

namespace PacmanGame.ReportManager
{
    public class ReportGenerate
    { 
        private readonly SqLiteConnection _sqLiteConnection = new SqLiteConnection();
        public void GetReport(int pacmanLastGeneration, int reportLastGeneration)
        {
            var reports = new List<Report>();
            for (var i = reportLastGeneration + 1; i <= pacmanLastGeneration; i++)
            {
                var oneGenerationPacman = _sqLiteConnection.GetOneGenerationPacmans(i);

                var report = new Report
                {
                    Generation = i,
                    MaxPoints =0,
                    MaxCountPositivePoints = 0,
                    MinAveragePoints = oneGenerationPacman.OrderBy(x=>x.AveragePoints).First().AveragePoints
                };
                var theFirst = oneGenerationPacman.OrderByDescending(x => x.AveragePoints).First();
                var theFirstPoints = IntHelper.GetPointsArr(theFirst.PointsString);
                report.MaxAveragePoints = theFirst.AveragePoints;
                report.MaxPointsOfFirst = theFirstPoints.OrderByDescending(x=>x).First();
                report.CountPositivePointsOfFirst = theFirstPoints.Where(x => x > 0).Count();

                foreach (var pacman in oneGenerationPacman)
                {
                    var pointsArr = IntHelper.GetPointsArr(pacman.PointsString);
                    var maxPoints = pointsArr.OrderByDescending(x => x).First();
                    var countPositivePoints = pointsArr.Where(x => x > 0).Count();

                    if (maxPoints > report.MaxPoints)
                    {
                        report.MaxPoints = maxPoints;
                        report.MaxPointsAveragePoints = pacman.AveragePoints;
                    }
                    if (countPositivePoints > report.MaxCountPositivePoints)
                    {
                        report.MaxCountPositivePoints = countPositivePoints;
                        report.MaxCountPositivePointsAveragePoints = pacman.AveragePoints;
                    }
                    
                }
                reports.Add(report);
            }
            _sqLiteConnection.InsertReport(reports);
        }

        
    }
}
