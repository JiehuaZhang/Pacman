using System;
using OperationManager.CheckerManager;
using OperationManager.DataManager;
using OperationManager.GameManager;
using OperationManager.StoreDataManager;
using PacmanGame.GameManager;
using PacmanGame.ReportManager;

namespace PacmanGame
{
    class Program
    {
        private static readonly Game Game = new Game(new StoreData(new SqLiteConnection()), new RunTheGame(), new GameResult());
        private static readonly GenerateChecker GenerateChecker = new GenerateChecker();
        private static readonly Reproduce Reproduct = new Reproduce();
        private static readonly SqLiteConnection SqLiteConnection = new SqLiteConnection();
        private static int _pacmanLastGeneration; 
        static void Main(string[] args)
        {
            if (IsNewStart())
            {
                var firstGeneration = new TheFirstGeneration(Game, GenerateChecker);
                firstGeneration.Play();
            }
            else
            {
                DoReport();
                Console.WriteLine("Give a number:");
                var number = Convert.ToInt32(Console.ReadLine());
                for (var i = 0; i < number; i++)
                {
                    var nextGenerationPacmans =new NextGeneration(Game, GenerateChecker, Reproduct, SqLiteConnection);
                    nextGenerationPacmans.Play();
                }
              
            }
        }

        private static bool  IsNewStart()
        {
            var ifTalbeExist = SqLiteConnection.IfTableExist();
            if (ifTalbeExist)
            {
                _pacmanLastGeneration = SqLiteConnection.GetLastGeneration();
                return _pacmanLastGeneration == 0;
            }
            return true;
        }

        private static void DoReport()
        {
            SqLiteConnection.CheckIfNeedToCreateReportTable();
            var reportLastGeneration = 0;
            if (SqLiteConnection.CheckIfNeedToDoReport(_pacmanLastGeneration,ref reportLastGeneration))
            {
                var reportGenerate = new ReportGenerate();
                reportGenerate.GetReport(_pacmanLastGeneration,reportLastGeneration);
            }
        }
    }

}
