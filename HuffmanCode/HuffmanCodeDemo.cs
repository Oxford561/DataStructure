using System;
using System.Collections.Generic;
using System.Text;

namespace DataStruct.HuffmanCode
{
    // 赫夫曼树的应用（压缩解压）
    public class HuffmanCodeDemo
    {
        public static void Test()
        {
            // 完成赫夫曼树的创建
            string content = "i like like like java do you like a java";
            byte[] contentBytes = System.Text.Encoding.Default.GetBytes(content);

            List<Node> lst = GetNodes(contentBytes);
            Node root = CreateHuffmanTree(lst);
            root.PreOrder();

            // 生成哈夫曼编码表
            Dictionary<Byte, string> huffmanCodeList = GetCodes(root);
            // 转换成压缩字节
            byte[] huffmanCodeBytes = Zip(contentBytes, huffmanCodeList);

            //Console.WriteLine(ByteToBitString((byte)-1);
        }

        #region 解压

        public static string ByteToBitString(byte b)
        {
            int temp = b;
            string str = Convert.ToString(temp, 2);
            return str;
        }

        #endregion


        // 将字符串对于的byte[] 通过生成的赫夫曼编码表返回赫夫曼编码压缩后的byte[]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes">原始字符串对于的字节数组</param>
        /// <param name="codes">赫夫曼编码表</param>
        /// <returns>压缩后的字节数组</returns>
        public static byte[] Zip(byte[] bytes, Dictionary<Byte, string> codes)
        {
            StringBuilder sbs = new StringBuilder();
            foreach (var item in bytes)
            {
                sbs.Append(codes[item]);
            }
            // 将 0110101010 转换成 byte[] 8位1字节  int len = sbs.Length+7 / 8   133
            int len;
            if (sbs.Length % 8 == 0)
            {
                len = sbs.Length / 8;
            }
            else
            {
                len = sbs.Length / 8 + 1;
            }

            byte[] huffmanCodeBytes = new byte[len];
            int index = 0;
            for (int i = 0; i < sbs.Length; i += 8)
            {
                string strByte = "";
                // 判断是否满8个长度
                if (i + 8 > sbs.Length)
                {
                    strByte = sbs.ToString().Substring(i);
                }
                else
                {
                    strByte = sbs.ToString().Substring(i, 8);
                }

                huffmanCodeBytes[index] = (byte)Int64.Parse(strByte);
                index++;
            }

            return huffmanCodeBytes;

        }

        // 生成赫夫曼编码表
        public static Dictionary<Byte, string> huffmanCodes = new Dictionary<byte, string>();
        public static StringBuilder sb = new StringBuilder();

        public static Dictionary<Byte, string> GetCodes(Node node)
        {
            if (node == null)
            {
                return null;
            }
            else
            {
                GetCodes(node.left, "0", sb);
                GetCodes(node.right, "1", sb);
            }

            return huffmanCodes;
        }

        // 将传入的 node 所有叶子节点的赫夫曼编码存放到 Dic
        public static void GetCodes(Node node, string code, StringBuilder stringBuilder)
        {
            StringBuilder sb2 = new StringBuilder(stringBuilder.ToString());
            sb2.Append(code);
            if (node != null)
            {
                if (node.data == 0)
                {
                    GetCodes(node.left, "0", sb2);
                    GetCodes(node.right, "1", sb2);
                }
                else
                {
                    // 叶子节点
                    huffmanCodes[node.data] = sb2.ToString();
                }
            }
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
                if (count == -1)
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
                Node parent = new Node(0, left.weight + right.weight);
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
