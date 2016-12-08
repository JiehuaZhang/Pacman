using System.Collections.Generic;
using CommonType;
using OperationManager.CheckerManager;
using OperationManager.StrategyManager;

namespace PacmanGame.GameManager
{
    public  class TheFirstGeneration
    {
        private readonly Game _game;
        private readonly GenerateChecker _generateChecker;
        public  TheFirstGeneration(Game game, GenerateChecker generateChecker)
        {
            _game = game;
            _generateChecker = generateChecker;
        }
        public void Play()
        {
            _game.Run(Get200NewPacman(), _generateChecker.GenerateInitialChecker());
        }

        private static List<Pacman> Get200NewPacman()
        {
            var newPacmans = new List<Pacman>();
            for (var i = 0; i < 200; i++)
            {
                var p = new Pacman
                {
                    Strategy = GenerateStartegy.FillRandomActionToSituation(GenerateSituationArray.GetSituationArray())
                };
                newPacmans.Add(p);
            }
            return newPacmans;
        } 
    }
}