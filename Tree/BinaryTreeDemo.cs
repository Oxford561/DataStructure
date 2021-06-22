using System;
using System.Collections.Generic;
using System.Text;

namespace DataStruct.Tree
{
    public class BinaryTreeDemo
    {
        public static void Test()
        {
            BinaryTree bt = new BinaryTree();
            HeroNode root = new HeroNode(1, "宋江");
            HeroNode hero2 = new HeroNode(2, "吴用");
            HeroNode hero3 = new HeroNode(3, "卢俊义");
            HeroNode hero4 = new HeroNode(4, "林冲");

            root.left = hero2;
            root.right = hero3;
            hero3.right = hero4;
            bt.SetRoot(root);
            Console.WriteLine("前序遍历:");
            bt.PreOrder();
            Console.WriteLine("中序遍历:");
            bt.InfixOrder();
            Console.WriteLine("后序遍历:");
            bt.PostOrder();
            Console.WriteLine("前序查找:");
            Console.WriteLine(bt.PreOrderSearch(1));
            Console.WriteLine("中序查找:");
            Console.WriteLine(bt.InfixOrderSearch(2));
            Console.WriteLine("后序查找:");
            Console.WriteLine(bt.PostOrderSearch(3));
        }
    }

    class BinaryTree
    {
        private HeroNode root;
        public void SetRoot(HeroNode root)
        {
            this.root = root;
        }

        //前序遍历
        public void PreOrder()
        {
            if (this.root != null)
            {
                this.root.PreOrder();
            }
            else
            {
                Console.WriteLine("二叉树为空无法遍历");
            }
        }

        // 中序遍历
        public void InfixOrder()
        {
            if (this.root != null)
            {
                this.root.InfixOrder();
            }
            else
            {
                Console.WriteLine("二叉树为空无法遍历");
            }
        }

        // 后序遍历
        public void PostOrder()
        {
            if (this.root != null)
            {
                this.root.PostOrder();
            }
            else
            {
                Console.WriteLine("二叉树为空无法遍历");
            }
        }

        // 前序查找
        public HeroNode PreOrderSearch(int no)
        {
            if(root != null)
            {
                return root.PreOrderSearch(no);
            }
            else
            {
                return null;
            }
        }

        // 中序查找
        public HeroNode InfixOrderSearch(int no)
        {
            if (root != null)
            {
                return root.InfixOrderSearch(no);
            }
            else
            {
                return null;
            }
        }

        // 后序查找
        public HeroNode PostOrderSearch(int no)
        {
            if (root != null)
            {
                return root.PostOrderSearch(no);
            }
            else
            {
                return null;
            }
        }
    }

    class HeroNode
    {
        private int no;
        private string name;
        public HeroNode left;
        public HeroNode right;
        public HeroNode(int no, string name)
        {
            this.no = no;
            this.name = name;
        }

        public override string ToString()
        {
            return "HeroNode [no=" + no + ",name=" + name + "]";
        }

        // 前序遍历
        public void PreOrder()
        {
            Console.WriteLine(this);
            //递归左子树前序遍历
            if (this.left != null)
            {
                this.left.PreOrder();
            }
            //递归右子树前序遍历
            if (this.right != null)
            {
                this.right.PreOrder();
            }
        }

        // 中序遍历
        public void InfixOrder()
        {
            //递归左子树中序遍历
            if (this.left != null)
            {
                this.left.InfixOrder();
            }
            // 输出父节点
            Console.WriteLine(this);
            //递归右子树中序遍历
            if (this.right != null)
            {
                this.right.InfixOrder();
            }
        }

        // 后序遍历
        public void PostOrder()
        {
            //递归左子树后序遍历
            if (this.left != null)
            {
                this.left.PostOrder();
            }
            //递归右子树后序遍历
            if (this.right != null)
            {
                this.right.PostOrder();
            }
            Console.WriteLine(this);
        }

        // 前序查找
        public HeroNode PreOrderSearch(int no)
        {
            if(this.no == no)
            {
                return this;
            }
            HeroNode resNode = null;
            if (this.left != null)
            {
                resNode = this.left.PreOrderSearch(no);
            }
            if(resNode != null)
            {
                return resNode;
            }

            if (this.right != null)
            {
                resNode = this.right.PreOrderSearch(no);
            }
            return resNode;
        }

        // 中序查找
        public HeroNode InfixOrderSearch(int no)
        {
            HeroNode resNode = null;
            if(this.left != null)
            {
                resNode = this.left.InfixOrderSearch(no);
            }
            if(resNode != null)
            {
                return resNode;
            }
            if(this.no == no)
            {
                return this;
            }
            if(this.right != null)
            {
                resNode = this.right.InfixOrderSearch(no);
            }
            return resNode;
        }

        // 后序查找
        public HeroNode PostOrderSearch(int no)
        {
            HeroNode resNode = null;
            if (this.left != null)
            {
                resNode = this.left.PostOrderSearch(no);
            }
            if (resNode != null)
            {
                return resNode;
            }
            if (this.right != null)
            {
                resNode = this.right.PostOrderSearch(no);
            }
            if (resNode != null)
            {
                return resNode;
            }
            if (this.no == no)
            {
                return this;
            }
            return resNode;
        }
    }
}