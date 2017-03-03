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
                pacman.MaxPoints= pointsArr.OrderByDescending(x => x).First();
                pacman.PositivePointsCount = pointsArr.Where(x => x > 0).Count();
                _sqLiteConnection.UpdatePacmansMaxPoints(pacman);
            }
        }

        public void UpdatePacmanWeight(int generation)
        {
            var oneGenerationPacman = _sqLiteConnection.GetOneGenerationPacmans(generation);
            foreach (var pacman in oneGenerationPacman)
            {
               var weight = pacman.AveragePoints + pacman.MaxPoints + pacman.PositivePointsCount;
                if (weight <= 0)
                {
                    pacman.Weight = 1;
                }
                else
                {
                    pacman.Weight = weight;
                }
                _sqLiteConnection.UpdateWeight(pacman);
            }
        }
    }
}
