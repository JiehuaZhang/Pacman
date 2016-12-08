using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonType;

namespace OperationManager.Interface
{
    public interface IStoreData
    {
        void StoreGameResult(List<Pacman> pacmans, Checker checker);
    }
}
