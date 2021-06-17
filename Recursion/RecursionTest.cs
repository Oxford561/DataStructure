using System;
using System.Collections.Generic;
using System.Text;

namespace DataStruct.Recursion
{
    public class RecursionTest
    {
        public static void Test()
        {
            Test(4);
            Factorial(4);
        }

        //打印问题
        public static void Test(int n)
        {
            if(n > 2)
            {
                Test(n - 1);
            }
            Console.WriteLine("n=" + n);
        }

        public static int Factorial(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return Factorial(n - 1) * n;
            }
        }
    }
}
