using System;
using System.Collections.Generic;
using CommonType;
using OperationManager.Helper;

namespace OperationManager.StrategyManager
{
    public static class GenerateStartegy
    {
        /// <summary>
        /// 0:↑;1:→;2:↓;3:←;4:Eat;5:Freeze;6:Random;
        /// </summary>
        /// <param name="situationArr"></param>
        /// <param name="rnd"></param>
        public static Strategy FillRandomActionToSituation(string[] situationArr, Random rnd)
        {
            var startegy = new KeyValuePair<string, int>[situationArr.Length];

            for (var i = 0; i < situationArr.Length; i++)
            {
                startegy[i] =new KeyValuePair<string, int>(situationArr[i], rnd.Next(7));
            }
            return new Strategy {Lines = startegy};
        }
    }
}
