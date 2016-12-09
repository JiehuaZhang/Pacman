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
        public static Strategy FillRandomActionToSituation(string[] situationArr)
        {
            var startegy = new KeyValuePair<string, int>[situationArr.Length];
            for (var i = 0; i < situationArr.Length; i++)
            {
                startegy[i] =new KeyValuePair<string, int>(situationArr[i],IntHelper.GetRandomAction());
            }
            return new Strategy {Lines = startegy};
        }
    }
}
