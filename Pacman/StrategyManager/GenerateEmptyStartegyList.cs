using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonType;

namespace StrategyManager
{
    public class GenerateEmptyStartegyList
    {
        /// <summary>
        /// a:up;b:right;c:button;d:left;e:center;
        /// </summary>
        /// <returns></returns>
        public StrategyList  GetEmptyList()
        {
            var list = new KeyValuePair<string, int>[243];
            var i = 0;
            for (var a = 0; a < 3; a++)
            {
                for (var b = 0; b < 3; b++)
                {
                    for (var c = 0; c < 3; c++)
                    {
                        for (var d = 0; d < 3; d++)
                        {
                            for (var e = 0; e < 3; e++)
                            {
                                var valuePair = new KeyValuePair<string, int>($"{a}{b}{c}{d}{e}", -1);
                                list[i] = valuePair;
                                i++;
                            }
                        }
                    }
                }
            }
            return new StrategyList {List = list};
        }
    }
}
