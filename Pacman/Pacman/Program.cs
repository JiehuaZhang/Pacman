using System.Collections.Generic;
using CommonType;
using OperationManager.CheckerManager;
using OperationManager.DataManager;
using OperationManager.GameManager;
using OperationManager.StoreDataManager;
using PacmanGame.GameManager;

namespace PacmanGame
{
    class Program
    {
        private static readonly Game Game = new Game(new StoreData(new SqLiteConnection()), new RunTheGame(), new GameResult());
        private static readonly GenerateChecker GenerateChecker = new GenerateChecker();
        private static readonly Reproduce Reproduct = new Reproduce();
        private static readonly SqLiteConnection SQLiteConnection = new SqLiteConnection();


        static void Main(string[] args)
        {
            if (IsNewStart())
            {
                var firstGeneration = new TheFirstGeneration(Game, GenerateChecker);
                firstGeneration.Play();
            }
            else
            {
                var nextGenerationPacmans =new NextGeneration(Game, GenerateChecker, Reproduct);
                nextGenerationPacmans.Play();
            }
        }

        private static bool  IsNewStart()
        {
            return SQLiteConnection.CheckIsNewStart();
        }
    }

}
