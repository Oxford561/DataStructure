using System;
using System.Collections.Generic;
using System.Text;

namespace DataStruct.Sort
{
    // O(n^2)
    public class InsertSort
    {
        public static void Test()
        {
            int[] arr = { 101, 34, 119, 1, -1, 89 };

            for (int i = 1; i < arr.Length; i++)
            {
                int insertVal = arr[i];
                int insertIndex = i - 1;
                while (insertIndex >= 0 && insertVal < arr[insertIndex])
                {
                    arr[insertIndex + 1] = arr[insertIndex];
                    insertIndex--;
                }
                if (insertIndex + 1 != i)
                {
                    arr[insertIndex + 1] = insertVal;
                }
            }
            Console.WriteLine("排序后：");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine(" ");
        }
    }
}
