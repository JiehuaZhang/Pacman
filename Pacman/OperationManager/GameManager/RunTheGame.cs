using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonType;
using OperationManager.Helper;
using OperationManager.Interface;

namespace OperationManager.GameManager
{
    public  class RunTheGame : IRunTheGame
    {
        public  void GetPoints(ref List<Pacman> pacmans, Checker checker)
        {
            foreach (var p in pacmans)
            {
                var position = FindStartCheck();
            }
        }

        private CheckPosition FindStartCheck()
        {
            var rnd = new Random();
            return new CheckPosition {Position = IntHelper.FindPositionFromRandomNumber(rnd.Next(1, 101))};
        }
    }
}
