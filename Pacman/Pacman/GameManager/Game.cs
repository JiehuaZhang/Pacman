using System;
using System.Collections.Generic;
using System.Linq;
using CommonType;
using OperationManager.GameManager;
using OperationManager.Interface;
using OperationManager.StoreDataManager;

namespace PacmanGame.GameManager
{
    public class Game
    {
        private readonly IStoreData _storeData;
        private readonly IRunTheGame _runTheGame;
        private readonly IGameResult _gameResult;
        private static readonly log4net.ILog Log =
     log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Game(IStoreData storeData, IRunTheGame runTheGame, IGameResult gameResult)
        {
            _storeData = storeData;
            _runTheGame = runTheGame;
            _gameResult = gameResult;
        }
        public void Run(Pacman[] pacmans, Checker[] checkers)
        {
            for (var i = 0; i < checkers.Length; i++)
            {
                _runTheGame.GetPoints(ref pacmans, checkers[i], i);
                Console.Write("\r{0}", i);
            }
            var rankingPacmans = _gameResult.GetRankingAndWeight(pacmans);
            var minpacman = rankingPacmans.OrderBy(x => x.AveragePoints).FirstOrDefault();
            var maxpacman = rankingPacmans.OrderByDescending(x => x.AveragePoints).FirstOrDefault();
            if (maxpacman != null)
            {
                var positivePointCount = maxpacman.Points.Where(x => x > 0).Count();

                Log.Info(
                    $"Generation: {maxpacman.Generation}, Max Average Points: {maxpacman.AveragePoints}, Min Average Points: {minpacman?.AveragePoints}, Max points of the first Pacman: {maxpacman.Points.OrderByDescending(x => x).First()}, Positive points count of the first Pacman: {positivePointCount}");
            }

            _storeData.StoreGameResult(rankingPacmans);
        }
    }
}
