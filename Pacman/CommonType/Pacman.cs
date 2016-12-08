using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonType
{
    public class Pacman
    {
        public int Points { get; set; }
        public Strategy Strategy { get; set; }
        public int Ranking { get; set; }
        public int Weight { get; set; }
        public string CheckerID { get; set; }
    }
}
