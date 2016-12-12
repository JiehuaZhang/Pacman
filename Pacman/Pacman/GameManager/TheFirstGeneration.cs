using System.Collections.Generic;
using CommonType;
using CommonType.Enum;
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
            _game.Run(Get200NewPacman(), _generateChecker.Generate1000Checkers());
        }

        private static Pacman[] Get200NewPacman()
        {
            var newPacmans = new Pacman[] {};
            for (var i = 0; i < (int)GameRules.NumberOfOneGenerationPacman; i++)
            {
                var p = new Pacman
                {
                    Strategy = GenerateStartegy.FillRandomActionToSituation(GenerateSituationArray.GetSituationArray()),
                    Generation =1
                };
                newPacmans[i] =p;
            }
            return newPacmans;
        } 
    }
}