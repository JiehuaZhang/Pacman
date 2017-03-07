using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperationManager.DataManager;
using OperationManager.Helper;

namespace OperationManager.Update
{
    public class UpgradeFromOldDatabase
    {
        private readonly SqLiteConnection _sqLiteConnection = new SqLiteConnection();
        public void UpdatePacman(int generation)
        {
            var oneGenerationPacman = _sqLiteConnection.GetOneGenerationPacmans(generation);
            foreach (var pacman in oneGenerationPacman)
            {
                var pointsArr = IntHelper.GetPointsArr(pacman.PointsString);
               // pacman.MaxPoints= pointsArr.OrderByDescending(x => x).First();
                pacman.PositivePointsCount = pointsArr.Where(x => x > 0).Count();
                _sqLiteConnection.UpdatePacmansMaxPoints(pacman);
            }
        }

        public void UpdatePacmanWeight(int generation)
        {
            var oneGenerationPacman = _sqLiteConnection.GetOneGenerationPacmans(generation);
            foreach (var p in oneGenerationPacman)
            {
                p.Points = IntHelper.GetPointsArr(p.PointsString);
               var weight = p.Points.Sum() > 1000 ? p.Points.Sum() + p.AveragePoints + p.MaxPoints + p.PositivePointsCount : p.AveragePoints + p.MaxPoints + p.PositivePointsCount;
                p.Weight = weight <= 0 ? 1 : weight;
                _sqLiteConnection.UpdateWeight(p);
            }
        }
    }
}
