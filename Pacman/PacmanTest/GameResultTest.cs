using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OperationManager.DataManager;
using OperationManager.GameManager;

namespace PacmanTest
{
    [TestClass]
    public class GameResultTest
    {
        [TestMethod]
        public void GetRankingAndWeightTest()
        {
            var sql = new SqLiteConnection();
            var pacmans = sql.GetOneGenerationPacmans(100);
            var gameResult = new GameResult();
            var rankingPacmans = gameResult.GetRankingAndWeight2(pacmans.ToArray());
            foreach (var p in rankingPacmans)
            {
                Console.WriteLine(p.AveragePoints + ":" + p.Weight);
            }
        }
    }
}
