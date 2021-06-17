using System;
using System.Collections.Generic;
using System.Text;

namespace DataStruct.Sort
{
    // O(n^2)
    public class SelectSort
    {
        public static void Test()
        {
            int[] arr = { 101, 34, 119, 1, -1, 90, 123 };
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minIndex = i;
                int min = arr[i];
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (min > arr[j])
                    {
                        min = arr[j];
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    arr[minIndex] = arr[i];
                    arr[i] = min;
                }
            }

            Console.WriteLine("排序后：");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}
