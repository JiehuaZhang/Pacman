using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CommonType;
using CommonType.Enum;
using OperationManager.Helper;

namespace PacmanGame.GameManager
{
    public  class Reproduce : IReproduce
    {

        public Pacman[] GetNextGenerationPacmans(Pacman[] lastGenerationPacmans)
        {
            var newGenearationPacman =new Pacman[(int)GameRules.NumberOfOneGenerationPacman];
            var thisGeneration = lastGenerationPacmans[0].Generation + 1;
            var weightList = new int[lastGenerationPacmans.Length];
            var proportionList = new double[lastGenerationPacmans.Length];

            for (var i = 0; i < lastGenerationPacmans.Length; i++)
            {
                weightList[i] = lastGenerationPacmans[i].Weight;
            }
            var weightSum = weightList.Sum();
            for (var i = 0; i < lastGenerationPacmans.Length; i++)
            {
                proportionList[i] = (double) weightList[i]/(double) weightSum;
            }
            var cutRnd = new Random();
            var actionRnd = new Random();
            var changeRnd = new Random();
            for (var i = 0; i < (int)GameRules.NumberOfOneGenerationPacman/2; i++)
            {
                var motherIndex = RandomHelper.GetRandomNumber(proportionList);
                var fatherIndex = RandomHelper.GetRandomNumber(proportionList);
                while (motherIndex == fatherIndex)
                {
                    fatherIndex = RandomHelper.GetRandomNumber(proportionList);
                }

                var cutIndex = cutRnd.Next(243);
                var motherStrategy = lastGenerationPacmans[motherIndex].Strategy;
                var fatherStrategy = lastGenerationPacmans[fatherIndex].Strategy;

                Console.WriteLine(new string('*',20));
                Console.WriteLine("Pacman parents " + i);
                Console.WriteLine("Mother:" + lastGenerationPacmans[motherIndex].Weight);
                Console.WriteLine("Father:" + lastGenerationPacmans[fatherIndex].Weight);

                var strategies = GenerateNewGenerationStrategy(motherStrategy, fatherStrategy, cutIndex);
                newGenearationPacman[i*2] = new Pacman
                {
                    Strategy = RandomChangeActions(strategies[0],1),
                    Generation = thisGeneration,
                    Points = new int[(int)GameRules.NumberOfOneGenerationChecker]
                };
                newGenearationPacman[i*2+1] = new Pacman
                {
                    Strategy = RandomChangeActions(strategies[1],1),
                    Generation = thisGeneration,
                    Points = new int[(int)GameRules.NumberOfOneGenerationChecker]
                };

            }
            return newGenearationPacman;
        }

        private Strategy[] GenerateNewGenerationStrategy(Strategy motherStrategy, Strategy fatherStrategy, int cutIndex)
        {
            var motherArray = motherStrategy.Lines;
            var fatherArray = fatherStrategy.Lines;
            var motherSubArray1 = motherArray.SubArray(0, cutIndex);
            var motherSubArray2 = motherArray.SubArray(cutIndex, 243 - cutIndex);
            var fatherSubArray1 = fatherArray.SubArray(0, cutIndex);
            var fatherSubArray2 = fatherArray.SubArray(cutIndex, 243 - cutIndex);
            var childArray1 = IntHelper.MergeArray(motherSubArray1, fatherSubArray2);
            var childArray2 = IntHelper.MergeArray(fatherSubArray1, motherSubArray2);
            return new[]
            {
                new Strategy
                {
                    Lines = childArray1
                },
                new Strategy
                {
                    Lines = childArray2
                },
            };

        }

        private Strategy RandomChangeAction(Strategy originalStrategy, int index, int randomAction)
        {
            originalStrategy.Lines[index] = new KeyValuePair<string, int>(originalStrategy.Lines[index].Key,randomAction);
            return new Strategy
            {
                Lines = originalStrategy.Lines,
            };
        }

        public Strategy RandomChangeActions(Strategy originalStrategy, int number)
        {
            var lastChangeIndex = -1;
            var actionRnd = new Random();
            var changeRnd = new Random();
            for (var i = 0; i < number; i++)
            {
                
                var randomAction = actionRnd.Next(7);
                var index = changeRnd.Next(243);
                while (index == lastChangeIndex)
                {
                    index = changeRnd.Next(243);
                }
                lastChangeIndex = index;
                while (randomAction == originalStrategy.Lines[index].Value)
                {
                    randomAction = actionRnd.Next(7);
                }
                originalStrategy.Lines[index] = new KeyValuePair<string, int>(originalStrategy.Lines[index].Key, randomAction);
            }
            return new Strategy
            {
                Lines = originalStrategy.Lines,
            };
        }


    }

    
}
