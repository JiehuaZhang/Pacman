using System;
using System.Linq;
using CommonType;
using OperationManager.Interface;

namespace OperationManager.GameManager
{
    public  class GameResult :IGameResult
    {
        public Pacman[] GetRankingAndWeight(Pacman[] pacmans)
        {
            foreach (var p in pacmans)
            {
                p.AveragePoints = p.Points.Sum()/ p.Points.Length;
                p.MaxPoints = p.Points.Select(x => x).Max();
                p.PositivePointsCount = p.Points.Select(x => x > 0).ToList().Count;
            }
            var newRankingPacman= (from pacman in pacmans
                                     select pacman).OrderByDescending(x => x.AveragePoints+x.MaxPoints+x.PositivePointsCount).ToArray();


            foreach (Pacman p in newRankingPacman)
            {
                var weight = p.AveragePoints+ p.MaxPoints+ p.PositivePointsCount;
                p.Weight = weight <= 0 ? 1 : weight;
            }
            return newRankingPacman;
        }
        
    }
}
