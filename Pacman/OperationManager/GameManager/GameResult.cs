using System;
using System.Linq;
using CommonType;
using OperationManager.Helper;
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
                p.PositivePointsCount = p.Points.Where(x => x > 0).ToList().Count;
            }
   


            foreach (var p in pacmans)
            {
                var weight =p.Points.Sum()>1000?p.Points.Sum() + p.AveragePoints + p.MaxPoints + p.PositivePointsCount : p.AveragePoints+ p.MaxPoints+ p.PositivePointsCount;
                p.Weight = weight <= 0 ? 1 : weight;
            }
            var newRankingPacman = (from pacman in pacmans
                                    select pacman).OrderByDescending(x => x.Weight).ToArray();

            return newRankingPacman;
        }
        public Pacman[] GetRankingAndWeight2(Pacman[] pacmans)
        {
            
            foreach (var p in pacmans)
            {
                p.Points = p.PointsString.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).Select(x=>Convert.ToInt32(x)).ToArray();
                p.AveragePoints = p.Points.Sum() / p.Points.Length;
                p.MaxPoints = p.Points.Select(x => x).Max();
                p.PositivePointsCount = p.Points.Where(x => x > 0).ToList().Count;
            }



            foreach (var p in pacmans)
            {
                var weight = p.Points.Sum() > 1000 ? p.Points.Sum() + p.AveragePoints  + p.MaxPoints  + p.PositivePointsCount * p.PositivePointsCount : p.AveragePoints + p.MaxPoints + p.PositivePointsCount;
                p.Weight = weight <= 0 ? 1 : weight;
            }

            return pacmans.OrderByDescending(x => x.Weight).ToArray(); 
        }

    }
}
