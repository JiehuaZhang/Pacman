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
                var possibleList = new List<int> { 0, 1, 2, 3, 4, 6 };
                if (situationArr[i][4].ToString() == "1")
                {
                    startegy[i] = new KeyValuePair<string, int>(situationArr[i], 4);
                }
                else
                {
                     if (situationArr[i][0].ToString() == "2")
                    {
                        possibleList.Remove(0);
                    }
                    if (situationArr[i][1].ToString() == "2")
                    {
                        possibleList.Remove(1);
                    }
                    if (situationArr[i][2].ToString() == "2")
                    {
                        possibleList.Remove(2);
                    }
                    if (situationArr[i][3].ToString() == "2")
                    {
                        possibleList.Remove(3);
                    }
                    if (situationArr[i][4].ToString() == "0")
                    {
                        possibleList.Remove(4);
                    }
                    var index = rnd.Next(possibleList.Count);
                    startegy[i] =new KeyValuePair<string, int>(situationArr[i],possibleList[index]);
                } 
            }
            return new Strategy {Lines = startegy};
        }
    }
}
