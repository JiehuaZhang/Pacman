using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonType;
using OperationManager.GameManager;

namespace PacmanGame
{
    public static class StartGame
    {
        public static void Start(ref List<Pacman> pacmans)
        {
            RunTheGame.GetPoints(ref pacmans);
            GameResult.GetRankingAndWeight(ref pacmans);
        }
    }
}
