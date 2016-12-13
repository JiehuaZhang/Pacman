using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using CommonType;
using OperationManager.Interface;

namespace OperationManager.GameManager
{
    public  class GameResult :IGameResult
    {
        public Pacman[] GetRankingAndWeight(Pacman[] pacmans)
        {
            for (var i=0;i<pacmans.Length;i++)
            {
                pacmans[i].AveragePoints = pacmans[i].Points.Sum()/ pacmans[i].Points.Length;
            }
           return (from pacman in pacmans
                select pacman).OrderBy(x => x.AveragePoints).ToArray();
        }
    }
}
