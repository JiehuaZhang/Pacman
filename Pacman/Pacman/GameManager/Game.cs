using System.Collections.Generic;
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

        public Game(IStoreData storeData, IRunTheGame runTheGame, IGameResult gameResult)
        {
            _storeData = storeData;
            _runTheGame = runTheGame;
            _gameResult = gameResult;
        }
        public void Run(Pacman[] pacmans, Checker[] checkers)
        {
            //for (var i = 0; i < pacmans.Length; i++)
            //{
            //    for (var j=0;j<checkers.Length;j++)
            //    {
            //        _runTheGame.StartMove(ref pacmans[i], _runTheGame.FindStartCheck(), checkers[j], j);
                    
            //    }
            //}

            for (var i = 0; i < checkers.Length; i++)
            {
                _runTheGame.GetPoints(ref pacmans, checkers[i], i);
            }
             _gameResult.GetRankingAndWeight(ref pacmans);
            _storeData.StoreGameResult(pacmans);
        }
    }
}
