using System;
using System.Collections.Generic;
using System.Linq;
using CommonType;
using CommonType.Enum;
using OperationManager.Helper;

namespace PacmanGame.GameManager
{
    public  class Reproduce
    {

        public Pacman[] GetNextGenerationPacmans(Pacman[] lastGenerationPacmans)
        {
            var newGenearationPacman =new Pacman[] {};
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
            for (int i = 0; i < (int)GameRules.NumberOfOneGenerationPacman; i++)
            {
                var motherIndex = RandomHelper.GetRandomNumber(proportionList);
                var fatherIndex = RandomHelper.GetRandomNumber(proportionList);
                while (motherIndex == fatherIndex)
                {
                    fatherIndex = RandomHelper.GetRandomNumber(proportionList);
                }

                var cutIndex = cutRnd.Next(0, 243);
                var motherStrategy = lastGenerationPacmans[motherIndex].Strategy;
                var fatherStrategy = lastGenerationPacmans[fatherIndex].Strategy;
                var  childPacman = new Pacman
                {
                    Generation = lastGenerationPacmans[0].Generation = thisGeneration,
                    Strategy = new Strategy
                    {
                        Lines = new []{}
                    }
                };

            }
            return newGenearationPacman;
        } 
    }
}
