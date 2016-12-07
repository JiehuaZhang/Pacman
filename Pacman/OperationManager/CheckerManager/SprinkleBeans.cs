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
            var arr = n.DigitArr();
            if (arr.Length == 3)
            {
                arr = new[] {10, arr[2] == 0 ? 10 : arr[2]};
            }
            else
            {
                arr = arr[1] == 0 ? new[] {arr[0] - 1, 10} : arr;
            }
            return arr;
        }
    }
}
