using System;
using System.Collections.Generic;
using System.Text;

namespace DataStruct.Sort
{
    public class QuickSort
    {
        public static void Test()
        {
            int[] arr = {-9,78,0,23,-567,70};
            quickSort(arr, 0, arr.Length - 1);
            Console.WriteLine("排序后的数组：");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        public static void quickSort(int[] arr,int left,int right)
        {
            int l = left;
            int r = right;
            int temp = 0;
            int pivot = arr[(left + right) / 2];
            while(l < r)
            {
                while(arr[l] < pivot)
                {
                    l += 1;
                }

                while (arr[r] > pivot)
                {
                    r -= 1;
                }

                if (l >= r)
                {
                    break;
                }

                temp = arr[l];
                arr[l] = arr[r];
                arr[r] = temp;

                if(arr[l] == pivot)
                {
                    r -= 1;
                }

                if(arr[r] == pivot)
                {
                    l += 1;
                }
            }

            if (l == r)
            {
                l += 1;
                r -= 1;
            }

            if(left < r)
            {
                quickSort(arr, left, r);
            }

            if(right > l)
            {
                quickSort(arr, l, right);
            }
        }
    }
}
