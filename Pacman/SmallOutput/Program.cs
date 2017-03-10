using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperationManager.CheckerManager;
using OperationManager.DataManager;
using OperationManager.GameManager;

namespace SmallOutput
{
    class Program
    {
        private static readonly GenerateChecker GenerateChecker = new GenerateChecker();
        private static readonly RunTheGame RunTheGame = new RunTheGame();
        static void Main(string[] args)
        {
            Console.WriteLine("What do you want?");
            Console.WriteLine("1. Run a strategy.");
            var number = Console.ReadLine();

            if (number == "1")
            {
                RunSingleStrategyMentod();
            }
        }

        private static void RunSingleStrategyMentod()
        {
            var checker = GenerateChecker.GenerateInitialChecker();
            var position = RunTheGame.FindStartCheck();
            Console.WriteLine("Generate:Order(1~200):");
            var input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                var inputArr = input.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);

                foreach (var generation in inputArr)
                {
                    var pacmanArr = generation.Split(new char[] {':'}, StringSplitOptions.RemoveEmptyEntries);
                    if(pacmanArr.Length!=2) continue;
                     
                    var generate = pacmanArr[0];
                    var pacmanOrder = pacmanArr[1];
                    var runAStrategy = new RunAStrategy(new RunTheGame(), new SqLiteConnection());
                    Console.WriteLine( runAStrategy.RunAStartegyToGetPoint(Convert.ToInt32(generate), Convert.ToInt32(pacmanOrder), position,checker));
                }
            }
            Console.ReadLine();
         
        }
    }
}
