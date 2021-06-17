using System;
using System.Collections.Generic;
using System.Text;

namespace DataStruct.Sort
{
    public class ShellSort
    {
        public static void Main(string[] args)
        {
            int[] arr = { 8, 9, 1, 7, 2, 3, 5, 4, 6, 0 };
            int temp = 0;
            // 希尔排序交换法
            //for (int gap = arr.Length/2; gap > 0; gap/=2)
            //{
            //    for (int i = gap; i < arr.Length; i++)
            //    {
            //        for (int j = i - gap; j >= 0; j-=gap)
            //        {
            //            if (arr[j]>arr[j+gap])
            //            {
            //                temp = arr[j];
            //                arr[j] = arr[j + gap];
            //                arr[j + gap] = temp;
            //            }
            //        }
            //    }
            //}

            // 希尔排序移动法
            for (int gap = arr.Length / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < arr.Length; i++)
                {
                    int j = i;
                    temp = arr[j];
                    if (arr[j] < arr[j - gap])
                    {
                        while(j-gap >=0 && temp < arr[j - gap])
                        {
                            arr[j] = arr[j - gap];
                            j -= gap;
                        }
                        arr[j] = temp;
                    }
                }
            }

            Console.WriteLine("排序后的数组：");

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
