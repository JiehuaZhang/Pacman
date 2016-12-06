using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonType;

namespace StrategyManager
{
    public class FillActionToList
    {
        /// <summary>
        /// 0:↑;1:↓;2:←;3:→;4:eat;5:hit the wall;6:random;
        /// </summary>
        /// <param name="strategy"></param>
        public void FillRandomActionToList(ref StrategyList strategy)
        {
            for (var i = 0; i < strategy.List.Length; i++)
            {
                var rnd = new Random();
                strategy.List[i].Value = rnd.Next(0, 7);
            }
        }
    }
}
