using System;
using System.Collections.Generic;
using System.Text;

namespace DataStruct.Search
{
    // 二分查找的前提是数组是有序的
    public class BinarySearch
    {
        public static void Test()
        {
            int[] arr = { 1,8,10,89,1000,1000,1000, 1000, 1234 };
            //int resIndex = binarySearch(arr, 0, arr.Length - 1, 0);
            //Console.WriteLine("二分查找到了结果："+resIndex);

            List<int> resList = binarySearch2(arr, 0, arr.Length - 1, 1000);
            foreach (var item in resList)
            {
                Console.Write(item+" ");
            }
        }

        public static int binarySearch(int[] arr,int left,int right,int findVal)
        {
            // left > right 递归结束
            if (left > right || findVal < arr[0] || findVal > arr[arr.Length - 1])
            {
                return -1;
            }

            int mid = (left + right) / 2;
            int midVal = arr[mid];
            if(findVal > midVal)
            {
                // 向右边递归
                return binarySearch(arr, mid + 1, right,findVal);
            }else if (findVal < midVal)
            {
                // 向左边递归
                return binarySearch(arr, left, mid-1, findVal);
            }
            else
            {
                return mid;
            }
        }

        // 找到多个相同值的时候返回多个下标
        public static List<int> binarySearch2(int[] arr, int left, int right, int findVal)
        {
            // left > right 递归结束
            if (left > right)
            {
                return new List<int>();
            }

            int mid = (left + right) / 2;
            int midVal = arr[mid];
            if (findVal > midVal)
            {
                // 向右边递归
                return binarySearch2(arr, mid + 1, right, findVal);
            }
            else if (findVal < midVal)
            {
                // 向左边递归
                return binarySearch2(arr, left, mid - 1, findVal);
            }
            else
            {
                List<int> lst = new List<int>();
                int temp = mid - 1;
                while (true)
                {
                    if(temp < 0 || arr[temp] != findVal)
                    {
                        break;
                    }
                    lst.Add(temp);
                    temp--;
                }
                lst.Add(mid);
                temp = mid + 1;
                while (true)
                {
                    if (temp > arr.Length-1 || arr[temp] != findVal)
                    {
                        break;
                    }
                    lst.Add(temp);
                    temp++;
                }

                return lst;
            }
        }
    }
}
