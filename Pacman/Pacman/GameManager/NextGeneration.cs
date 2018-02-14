using System.Collections.Generic;
using CommonType;
using OperationManager.CheckerManager;
using OperationManager.DataManager;

namespace PacmanGame.GameManager
{
    public  class NextGeneration : IGeneration
    {
        private readonly IGame _game;
        private readonly IGenerateChecker _generateChecker;
        private readonly IReproduce _reproduce;
        private readonly ISqLiteConnection _sqLiteConnection;
        public NextGeneration(IGame game, IGenerateChecker generateChecker, IReproduce reproduce, ISqLiteConnection sqLiteConnection)
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
