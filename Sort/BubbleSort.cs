using System;
using System.Collections.Generic;
using System.Text;

namespace DataStruct.Sort
{
    // O(n^2)
    public class BubbleSort
    {
        public static void Test()
        {
            int[] arr = { 3, 9, -1, 10, -2 };
            int temp = 0;
            bool flag = false;
            // 理解不了就记住多次排序，第一次排序只是把最大的数排到最后
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    //前面的数大于后面的数则进行交换
                    if (arr[j] > arr[j + 1])
                    {
                        flag = true;
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
                // 排序过程中一次都没有发生交换
                if (flag == false)
                {
                    break;
                }
                else
                {
                    flag = false; // 为下次排序重置
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}
