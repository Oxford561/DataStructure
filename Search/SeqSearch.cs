using System;
using System.Collections.Generic;
using System.Text;

namespace DataStruct.Search
{
    public class SeqSearch
    {
        public static void Test()
        {
            int[] arr = { 1, 9, 11, -1, 34, 89 };
            int res = seqSearch(arr, 11);
            if(res == -1)
            {
                Console.WriteLine("没有找到！");
            }
            else
            {
                Console.WriteLine("找到了下标："+res);
            }
        }

        public static int seqSearch(int[] arr, int value)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
