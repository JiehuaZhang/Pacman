using System.Linq;
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
            var newRankingPacman= (from pacman in pacmans
                                     select pacman).OrderByDescending(x => x.Points.Sum()).ToArray();
            var lastPoints = newRankingPacman[newRankingPacman.Length - 1].Points.Sum();
            for (var i = 0; i < newRankingPacman.Length; i++)
            {
                var weight = newRankingPacman[i].Points.Sum() - lastPoints;
                if (weight == 0)
                {
                    newRankingPacman[i].Weight = 1;
                }
                else
                {
                     newRankingPacman[i].Weight = weight;
                }
            }
            return newRankingPacman;
        }
    }
}
