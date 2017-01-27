using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonType
{
    public class Report
    {
        public int Generation { get; set; }
        public int MaxAveragePoints { get; set; }
        public int MinAveragePoints { get; set; }
        public int MaxPointsOfFirst { get; set; }
        public int CountPositivePointsOfFirst { get; set; }
        public int MaxPoints { get; set; }
        public int MaxPointsAveragePoints { get; set; }
        public int MaxCountPositivePoints { get; set; }
        public int MaxCountPositivePointsAveragePoints { get; set; }
    }
}
