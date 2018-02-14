using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationManager.GameManager
{
    public interface IRandomProvider
    {
        int GetNext(Random rnd, int lessThan);
    }
}
