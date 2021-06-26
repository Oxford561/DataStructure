using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace DataStruct.HuffManTree
{
    public class HuffManTreeDemo
    {
        public static void Test()
        {
            int[] arr = {13,7,8,3,29,6,1 };
            Node root = CreateHuffmanTree(arr);
            root.PreOrder();
        }

        public static Node CreateHuffmanTree(int[] arr)
        {
            List<Node> nodes = new List<Node>();
            for (int i = 0; i < arr.Length; i++)
            {
                nodes.Add(new Node(arr[i]));
            }

            while(nodes.Count > 1)
            {
                //排序 小-大
                nodes.Sort();
                //取出前两个权值最小的两颗二叉树
                Node left = nodes[0];
                Node right = nodes[1];

                // 构建新的二叉树
                Node parent = new Node(left.value + right.value);
                parent.left = left;
                parent.right = right;
                //从 list 中删除处理过的二叉树
                nodes.Remove(left);
                nodes.Remove(right);
                nodes.Add(parent);
            }

            // 返回赫夫曼树的root节点
            return nodes[0];
        }
    }

    //节点类
    public class Node: IComparable
    {
        public int value;//节点权值
        public Node left;//左子节点
        public Node right;//右子节点

        public Node(int value)
        {
            this.value = value;
        }

        public int CompareTo(object obj)
        {
            //从小到大排序
            Node p = obj as Node;
            return this.value.CompareTo(p.value);
        }

        public override string ToString()
        {
            return "Node[value="+value+"]";
        }

        // 前序遍历
        public void PreOrder()
        {
            Console.WriteLine(this);
            if(this.left != null)
            {
                this.left.PreOrder();
            }
            if (this.right != null)
            {
                this.right.PreOrder();
            }
        }
    }

}
