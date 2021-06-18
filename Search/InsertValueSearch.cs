using System;
using System.Collections.Generic;
using System.Text;

namespace DataStruct.Search
{
    public class InsertValueSearch
    {
        public static void Test()
        {
            int[] arr = new int[100];
            for (int i = 0; i < 100; i++)
            {
                arr[i] = i + 1;
            }

            int res = insertValueSearch(arr, 0, arr.Length - 1, 100);
            Console.WriteLine(res);
        }

        public static int insertValueSearch(int[] arr,int left,int right,int findVal)
        {
            if(left > right || findVal < arr[0] || findVal > arr[arr.Length - 1])
            {
                return -1;
            }
            int mid = left + (right - left) * (findVal - arr[left]) / (arr[right] - arr[left]);
            int midVal = arr[mid];
            if (findVal > midVal)
            {
                // 向右边递归
                return insertValueSearch(arr, mid + 1, right, findVal);
            }
            else if (findVal < midVal)
            {
                // 向左边递归
                return insertValueSearch(arr, left, mid - 1, findVal);
            }
            else
            {
                return mid;
            }
        }
    }
}
