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
            else if (arr.Length == 1)
            {
                arr = new[] {1, arr[0]};
            }
            else
            {
                if (arr[0] == 1 && arr[1] == 0)
                {
                    arr = new[] {1, 10};
                }
                else
                {
                    arr = arr[1] == 0 ? new[] { arr[0] - 1, 10 } : arr;
                }
               
            }
            return arr;
        }

        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        public static T[] MergeArray<T>( T[] source1, T[] source2)
        {
            var result = new T[source1.Length + source2.Length];
            Array.Copy(source1,result,source1.Length);
            Array.Copy(source2, 0,result,source1.Length,source2.Length);
            return result;
        }
    }
}
