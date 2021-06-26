using System;
using System.Collections.Generic;
using System.Text;

namespace DataStruct.Tree
{
    // 堆排序 O(nLogn)
    public class HeapSort
    {
        public static void Test()
        {
            int[] arr = { 4, 6, 8, 5, 9 };
            Sort(arr);
        }

        public static void Sort(int[] arr)
        {
            Console.WriteLine("堆排序");
            // 遍历所有的非叶子节点调整成大顶堆
            for (int i = arr.Length / 2 -1; i >= 0; i--)
            {
                AdajustHeap(arr, i, arr.Length);
            }
            Show(arr);
            int temp = 0;
            for (int j = arr.Length - 1; j > 0; j--)
            {
                //交换
                temp = arr[j];
                arr[j] = arr[0];
                arr[0] = temp;
                AdajustHeap(arr, 0, j);
            }
            Show(arr);
        }

        public static void Show(int[] arr)
        {
            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]+" ");
            }
        }

        /// <summary>
        /// 将数组（二叉树），调整成一个大顶堆
        /// （4，6，8，5，9）=》（4，9，8，5，6）=》（4，9，8，5，6）=》（9，6，8，5，4）
        /// </summary>
        /// <param name="arr">待调整的数组</param>
        /// <param name="i">表示非叶子节点在数组中的索引</param>
        /// <param name="lenght">表示对多少个元素继续调整</param>
        public static void AdajustHeap(int[] arr,int i,int length)
        {
            int temp = arr[i];
            // 开始调整
            for (int k = i*2+1; k < length; k = k * 2 + 1)
            {
                // 左子节点 < 右子节点
                if(k+1 < length && arr[k]<arr[k+1])
                {
                    k++;
                }
                // 子节点 > 父节点
                if (arr[k] > temp)
                {
                    arr[i] = arr[k];// 大值赋予当前节点
                    i = k;
                }
                else
                {
                    break;
                }
            }

            // 当for循环结束，以 i 为父节点的数的最大值已经放在局部顶端
            arr[i] = temp;
        }
    }
}
