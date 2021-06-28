using System;
using System.Collections.Generic;
using System.Text;

namespace DataStruct.BinarySortTree
{
    public class BinarySortTreeDemo
    {
        public static void Test()
        {
            int[] arr = {7,3,10,12,5,1,9 };
            BinarySortTree bst = new BinarySortTree();
            for (int i = 0; i < arr.Length; i++)
            {
                bst.Add(new Node(arr[i]));
            }
            Console.WriteLine("中序遍历二叉排序树");
            bst.InfixOrder();
        }
    }


    public class BinarySortTree
    {
        public Node root;
        public void Add(Node node)
        {
            if(root == null) {
                root = node;
            }
            else
            {
                root.Add(node);
            }
        }

        public void InfixOrder()
        {
            if(root != null)
            {
                root.InfixOrder();
            }
            else
            {
                Console.WriteLine("二叉排序树为空，不能遍历");
            }
        }
    }

    public class Node {
        public int value;
        public Node left;
        public Node right;

        public Node(int value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return "Node[value="+value+"]";
        }

        // 添加节点,满足二叉排序树
        public void Add(Node node)
        {
            if(node == null)
            {
                return;
            }

            //传入节点和当前子树的根节点进行比较
            if(node.value < this.value)
            {
                if(this.left == null)
                {
                    this.left = node;
                }
                else
                {
                    this.left.Add(node);
                }
            }
            else
            {
                if(this.right == null)
                {
                    this.right = node;
                }
                else
                {
                    this.right.Add(node);
                }
            }
        }

        public void InfixOrder()
        {
            if(this.left != null)
            {
                this.left.InfixOrder();
            }
            Console.WriteLine(this);
            if(this.right != null)
            {
                this.right.InfixOrder();
            }
        }
    }
}
