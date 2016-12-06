using System;
using OperationManager.Startegy;

namespace Output
{
    class Program
    {
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
    }
}
