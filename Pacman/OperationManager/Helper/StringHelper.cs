using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonType;

namespace OperationManager.Helper
{
    public  static class StringHelper
    {
        public static string GenerateStrategyString(Strategy strategy)
        {
            var sb = new StringBuilder();
            foreach (KeyValuePair<string, int> line in strategy.Lines)
            {
                sb.Append($"{line.Key}:{line.Value},");
            }
            return sb.ToString();
        }

        public static Strategy ConvertStringToStarategy(string strategyStr)
        {
            var strategy = new Strategy
            {
                Lines =  new KeyValuePair<string, int>[243]
            };
            var strArr = strategyStr.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
            if (strArr.Length == 243)
            {
                for (var i = 0; i < strArr.Length; i++)
                {
                    var str = strArr[i].Split(new[] {':'}, StringSplitOptions.RemoveEmptyEntries);
                    strategy.Lines[i] = new KeyValuePair<string, int>(str[0], Convert.ToInt32(str[1])); 
                }
            }
            return strategy;
        }
    }
}
