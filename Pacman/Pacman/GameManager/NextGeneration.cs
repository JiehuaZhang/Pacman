using System.Collections.Generic;
using CommonType;
using OperationManager.CheckerManager;
using OperationManager.DataManager;

namespace PacmanGame.GameManager
{
    public  class NextGeneration
    {
        private readonly Game _game;
        private readonly GenerateChecker _generateChecker;
        private readonly Reproduce _reproduce;
        private readonly SqLiteConnection _sqLiteConnection;
        public NextGeneration(Game game, GenerateChecker generateChecker, Reproduce reproduce, SqLiteConnection sqLiteConnection)
        {
            _game = game;
            _generateChecker = generateChecker;
            _reproduce = reproduce;
            _sqLiteConnection = sqLiteConnection;
        }

        public void Play()
        {
            _game.Run(_reproduce.GetNextGenerationPacmans(GetLastGenerationPacmans()), _generateChecker.Generate1000Checkers());
        }

        private Pacman[] GetLastGenerationPacmans()
        {
            var lastGeneration = _sqLiteConnection.GetLastGeneration();
            var last = _sqLiteConnection.GetOneGenerationPacmans(lastGeneration).ToArray();
            return last;
        }

    }
}
