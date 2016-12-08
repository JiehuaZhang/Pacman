using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonType
{
    public class Checker
    {
        public string ID { get; set; }
        public Dictionary<CheckPosition, int[]> Checks { get; set; } 
    }
}
