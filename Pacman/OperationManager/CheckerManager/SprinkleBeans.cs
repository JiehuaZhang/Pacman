using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperationManager.Helper;

namespace OperationManager.CheckerManager
{
    public static class SprinkleBeans
    {
        public static List<int[]> GetRandomSprinkleBeansPosition()
        {
            var rnd = new Random();
            var list = new List<int[]>();
            for (var i = 0; i < 50; i++)
            {
                var arr = GenerateBeanPosition(rnd);
                while (list.Any(x=>x.SequenceEqual(arr)))
                {
                    arr = GenerateBeanPosition(rnd);
                }
                list.Add(arr);
            }
            return list;
        }

        private static int[] GenerateBeanPosition(Random rnd)
        {
            var n = rnd.Next(11, 111);
            return IntHelper.FindPositionFromRandomNumber(n);
        }

        
    }
}
