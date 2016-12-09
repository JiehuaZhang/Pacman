using System.Collections.Generic;
using CommonType;
using OperationManager.CheckerManager;

namespace PacmanGame.GameManager
{
    public  class NextGeneration
    {
        private readonly Game _game;
        private readonly GenerateChecker _generateChecker;
        private readonly Reproduce _reproduce;
        public NextGeneration(Game game, GenerateChecker generateChecker, Reproduce reproduce)
        {
            _game = game;
            _generateChecker = generateChecker;
            _reproduce = reproduce;
        }

        public void Play()
        {
            _game.Run(_reproduce.GetNextGenerationPacmans(GetLastGenerationPacmans()), _generateChecker.Generate1000Checkers());
        }

        private Pacman[] GetLastGenerationPacmans()
        {
            var last = new Pacman[] {};
            //todo
            return last;
        }

    }
}
