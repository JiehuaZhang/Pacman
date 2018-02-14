using System;
using System.Collections.Generic;
using CommonType;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OperationManager.DataManager;
using PacmanGame.ReportManager;

namespace PacmanTest
{
    [TestClass]
    public class ReportGenerateTest
    {
        [TestMethod]
        public void GetReportTest()
        {
            var oneGenerationPacman = new List<Pacman>
            {
                new Pacman{ID =1, AveragePoints = 73, Generation = 3,MaxPoints = 543,Points =new []{0,13,36,33,56,543,0,-5, -15}, PointsString ="0,13,36,33,56,543,0,-5,-15",PositivePointsCount = 5, Strategy = new Strategy(), Weight = 345},
                new Pacman{ID =2, AveragePoints = 87, Generation = 3,MaxPoints = 332,Points =new []{0,200,200,13,56,332,4,-5, -15}, PointsString ="0,200,200,13,56,332,4,-5, -15",PositivePointsCount = 6, Strategy = new Strategy(), Weight =34556 },
               
            };


            var mockSqlConnect = new Mock<ISqLiteConnection>();
            mockSqlConnect.Setup(x => x.GetOneGenerationPacmans(3)).Returns(oneGenerationPacman);

            var reportGenerate = new ReportGenerate(mockSqlConnect.Object);

            var report = reportGenerate.CalculateReport(3);
            var expectReport = new Report
            {
                Generation = 3,
                MaxAveragePoints = 87,
                MinAveragePoints = 73,
                MaxPointsOfFirst = 332,
                CountPositivePointsOfFirst = 6,
                MaxPoints = 543,
                MaxCountPositivePoints = 6,
                MaxCountPositivePointsAveragePoints = 87,
                MaxPointsAveragePoints = 73
            };

            Assert.IsTrue(report.Generation == expectReport.Generation);
            Assert.IsTrue(report.MaxAveragePoints == expectReport.MaxAveragePoints);
            Assert.IsTrue(report.MinAveragePoints == expectReport.MinAveragePoints);
            Assert.IsTrue(report.MaxPointsOfFirst == expectReport.MaxPointsOfFirst);
            Assert.IsTrue(report.CountPositivePointsOfFirst == expectReport.CountPositivePointsOfFirst);
            Assert.IsTrue(report.MaxPoints == expectReport.MaxPoints);
            Assert.IsTrue(report.MaxCountPositivePoints == expectReport.MaxCountPositivePoints);
            Assert.IsTrue(report.MaxCountPositivePointsAveragePoints == expectReport.MaxCountPositivePointsAveragePoints);
            Assert.IsTrue(report.MaxPointsAveragePoints == expectReport.MaxPointsAveragePoints);
        }
    }
}
