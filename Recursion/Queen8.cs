using System;
using System.Collections.Generic;
using System.Text;

namespace DataStruct.Recursion
{
    public class Queen8
    {
        static int max = 8;
        static int count = 0;
        static int[] arr = new int[max];
        public static void Main(string[] args)
        {
            Check(0);
            Console.WriteLine("八皇后解法： " + count);
        }

        public static void Check(int n)
        {
            if(n == max)
            {
                Show();
                return;
            }

            for (int i = 0; i < max; i++)
            {
                arr[n] = i;
                if (Judge(n))
                {
                    Check(n + 1);
                }
            }
        }

        // 判断冲突（皇后处在同一列同一行同一斜线上皆为冲突）
        public static bool Judge(int n)
        {
            for (int i = 0; i < n; i++)
            {
                if(arr[i] == arr[n] || Math.Abs(n-i) == Math.Abs(arr[n] - arr[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static void Show()
        {
            count++;
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
