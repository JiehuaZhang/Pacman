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
    }
}
