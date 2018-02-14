using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationManager.GameManager
{
    public class RandomProvider : IRandomProvider
    {
        public int GetNext(Random rnd, int lessThan)
        {
            return rnd.Next(lessThan);
        }
    }
}
