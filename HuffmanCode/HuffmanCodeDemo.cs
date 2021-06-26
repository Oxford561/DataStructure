using System;
using System.Collections.Generic;
using System.Text;

namespace DataStruct.HuffmanCode
{
    public class HuffmanCodeDemo
    {
        public static void Test()
        {
            string content = "i like like like java do you like a java";
            byte[] contentBytes = System.Text.Encoding.Default.GetBytes(content);
            Console.WriteLine(content.Length);
            List<Node> lst = GetNodes(contentBytes);
            //foreach (var item in lst)
            //{
            //    Console.WriteLine(item);
            //}
            Node root = CreateHuffmanTree(lst);
            root.PreOrder();
        }

        private static List<Node> GetNodes(byte[] bytes)
        {
            List<Node> nodes = new List<Node>();
            //储存每个byte出现的次数
            Dictionary<Byte, int> counts = new Dictionary<byte, int>();
            foreach (var item in bytes)
            {
                int count = -1;
                counts.TryGetValue(item, out count);
                if(count == -1)
                {
                    counts[item] = 1;
                }
                else
                {
                    counts[item] = count + 1;
                }
            }

            foreach (var item in counts)
            {
                nodes.Add(new Node(item.Key, item.Value));
            }
            return nodes;
        }

        public static Node CreateHuffmanTree(List<Node> nodes)
        {
            while (nodes.Count > 1)
            {
                //排序 小-大
                nodes.Sort();
                //取出前两个权值最小的两颗二叉树
                Node left = nodes[0];
                Node right = nodes[1];

                // 构建新的二叉树
                Node parent = new Node(0,left.weight + right.weight);
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

    public class Node : IComparable
    {
        public Byte data;//数据本身
        public int weight;// 权值，字符出现的次数
        public Node left;
        public Node right;

        public Node(Byte data, int weight)
        {
            this.data = data;
            this.weight = weight;
        }
        public int CompareTo(object obj)
        {
            //从小到大排序
            Node p = obj as Node;
            return this.weight.CompareTo(p.weight);
        }

        public override string ToString()
        {
            return "Node[data=" + data + " weight=" + weight + "]";
        }

        // 前序遍历
        public void PreOrder()
        {
            Console.WriteLine(this);
            if (this.left != null)
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
