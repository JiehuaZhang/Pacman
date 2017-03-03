using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonType
{
    public class Pacman
    {
        public int ID { get; set; }
        public int[] Points { get; set; }
        public Strategy Strategy { get; set; }
        public int Weight { get; set; }
        public int Generation { get; set; }
        public int AveragePoints { get; set; }
        public string PointsString { get; set; }
        public int PositivePointsCount { get; set; }
        public int MaxPoints { get; set; }
    }
}
