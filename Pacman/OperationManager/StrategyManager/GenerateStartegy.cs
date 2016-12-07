using System;
using System.Collections.Generic;
using CommonType;

namespace OperationManager.StrategyManager
{
    public static class GenerateStartegy
    {
        /// <summary>
        /// 0:↑;1:↓;2:←;3:→;4:eat;5:hit the wall;6:random;
        /// </summary>
        /// <param name="situationArr"></param>
        public static Strategy FillRandomActionToSituation(string[] situationArr)
        {
            var startegy = new KeyValuePair<string, int>[situationArr.Length];
            var rnd = new Random();
            for (var i = 0; i < situationArr.Length; i++)
            {
                startegy[i] =new KeyValuePair<string, int>(situationArr[i],rnd.Next(7));
            }
            return new Strategy {Lines = startegy};
        }
    }
}
