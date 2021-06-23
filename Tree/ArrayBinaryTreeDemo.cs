using System;
using System.Collections.Generic;
using System.Text;

namespace DataStruct.Tree
{
    public class ArrayBinaryTreeDemo
    {
        public static void Test()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            ArrayBinaryTree abt = new ArrayBinaryTree(arr);
            abt.PreOrder();
        }
    }

    /**
     * 顺序存储二叉树通常只考虑完全二叉树
     * 第n个元素的左节点为 2*n+1
     * 第n个元素的右节点为 2*n+2
     * 第n个元素的父节点为 (n-1)/2
     */
    class ArrayBinaryTree
    {
        private int[] arr;
        public ArrayBinaryTree(int[] arr)
        {
            this.arr = arr;
        }

        public void PreOrder()
        {
            this.PreOrder(0)
        }

        // index 数组的下标
        public void PreOrder(int index)
        {
            // 如果数组为空，arr.length  = 0
            if(arr == null || arr.Length == 0)
            {
                Console.WriteLine("数组为空不能前序遍历");
                return;
            }
            Console.WriteLine(arr[index]);
            //向左
            if ((2 * index + 1) < arr.Length)
            {
                PreOrder(2 * index + 1);
            }

            //向右
            if ((2 * index + 2) < arr.Length)
            {
                PreOrder(2 * index + 2);
            }
        }
    }
}
