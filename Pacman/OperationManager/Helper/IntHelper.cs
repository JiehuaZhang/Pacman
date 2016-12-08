using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationManager.Helper
{
    public static class IntHelper
    {
        public static int[] DigitArr(this int n)
        {
            if (n == 0) return new int[1] { 0 };

            var digits = new List<int>();

            for (; n != 0; n /= 10)
                digits.Add(n % 10);

            var arr = digits.ToArray();
            Array.Reverse(arr);
            return arr;
        }

        public static int[] FindPositionFromRandomNumber(int n)
        {
            var arr = n.DigitArr();
            if (arr.Length == 3)
            {
                arr = new[] { 10, arr[2] == 0 ? 10 : arr[2] };
            }
            else
            {
                arr = arr[1] == 0 ? new[] { arr[0] - 1, 10 } : arr;
            }
            return arr;
        }
    }
}
