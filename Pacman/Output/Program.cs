using System;
using System.Linq;
using OperationManager.CheckerManager;
using OperationManager.GameManager;
using OperationManager.StoreDataManager;
using OperationManager.StrategyManager;

namespace Output
{
    class Program
    {
        private static readonly GenerateChecker GenerateChecker = new GenerateChecker();
        static void Main(string[] args)
        {

            Console.WriteLine("Enter function:");
            var id = Console.ReadLine();
            switch (id)
            {
                case "1":
                    OutputEmptyStartegyList();
                    break;
                case "2":
                    OutputStrategyArray();
                    break;
                case "3":
                    OutputEmptyChecker();
                    break;
                case "4":
                    OutputRandomBeans();
                    break;
                case "5":
                    OutputRandomBeanChecker();
                    break;
                default:
                    Console.WriteLine("Enter the right number.");
                    break;
            }
            Console.ReadKey();
        }
        private static void OutputEmptyStartegyList()
        {
            var strategy = GenerateSituationArray.GetSituationArray();
            for (var i = 0; i < strategy.Length; i++)
            {
                Console.WriteLine($"{i}:{strategy[i]}");
            }
        }

        private static void OutputStrategyArray()
        {
            var startegy = GenerateStartegy.FillRandomActionToSituation(GenerateSituationArray.GetSituationArray());
            foreach (var l in startegy.Lines)
            {
                Console.WriteLine($"{l.Key}:{l.Value}");
            }
        }

        private static void OutputEmptyChecker()
        {
            var checker = GenerateChecker.GenerateEmptyChecker();
            foreach (var key in checker.Checks.Keys)
            {
                Console.WriteLine($"{key.Position[0]}:{key.Position[1]}");
            }
        }

        private static void OutputRandomBeans()
        {
            var list = SprinkleBeans.GetRandomSprinkleBeansPosition();
            var i = 0;
            foreach (var p in list)
            {
                Console.WriteLine($"{i}   {p[0]}:{p[1]}");
                i++;
            }
        }

        private static void OutputRandomBeanChecker()
        {
            var list = SprinkleBeans.GetRandomSprinkleBeansPosition();
            var i = 0;
            foreach (var l in list.OrderBy(x=>x[0]).ThenBy(x=>x[1]).ToArray())
            {
                Console.WriteLine($"{i}   {l[0]}:{l[1]}");
                i++;
            }
            var checker= GenerateChecker.GenerateInitialChecker();
            foreach (var key in checker.Checks.Keys)
            {
                Console.WriteLine($"{key.Position[0]}:{key.Position[1]}--[{checker.Checks[key][0]}][{checker.Checks[key][1]}][{checker.Checks[key][2]}][{checker.Checks[key][3]}][{checker.Checks[key][4]}]");
            }
        }
    }
}
