using System;
using System.Collections.Generic;
using System.Text;

namespace DataStruct.Tree
{
    // 线索二叉树
    public class ThreadedBinaryTreeDemo
    {
        public static void Test()
        {
            HeroNode2 root = new HeroNode2(1, "宋江");
            HeroNode2 hero2 = new HeroNode2(3, "吴用");
            HeroNode2 hero3 = new HeroNode2(6, "卢俊义");
            HeroNode2 hero4 = new HeroNode2(8, "林冲");
            HeroNode2 hero5 = new HeroNode2(10, "林冲X");
            HeroNode2 hero6 = new HeroNode2(14, "林冲XX");

            root.left = hero2;
            root.right = hero3;
            hero2.left = hero4;
            hero2.right = hero5;
            hero3.left = hero6;

            ThreadedBinaryTree tbt = new ThreadedBinaryTree();
            tbt.SetRoot(root);
            tbt.ThreadedNodes();

            // 1 3 6 8 10 14 =》 8 3 10 1 14 6
            Console.WriteLine("10号的前驱节点是 "+hero5.left.no); 
            Console.WriteLine("10号的后继节点是 " + hero5.right.no);
        }
    }

    // 线索化二叉树
    class ThreadedBinaryTree
    {
        public HeroNode2 pre = null;
        public HeroNode2 root = null;

        public void ThreadedNodes()
        {
            this.ThreadedNodes(this.root);
        }

        // 中序线索化
        public void ThreadedNodes(HeroNode2 node)
        {
            if(node == null)
            {
                return;
            }

            // 先线索化左子树
            ThreadedNodes(node.left);
            // 线索化当前节点
            if(node.left == null)
            {
                node.left = pre;
                node.leftType = 1;
            }
            if(pre != null && pre.right == null)
            {
                pre.right = node;
                pre.rightType = 1;
            }

            pre = node;

            // 线索化右子树
            ThreadedNodes(node.right);
        }

        
        public void SetRoot(HeroNode2 root)
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
        public HeroNode2 PreOrderSearch(int no)
        {
            if (root != null)
            {
                return root.PreOrderSearch(no);
            }
            else
            {
                return null;
            }
        }

        // 中序查找
        public HeroNode2 InfixOrderSearch(int no)
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
        public HeroNode2 PostOrderSearch(int no)
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

        public void DelNode(int no)
        {
            if (this.root != null)
            {
                if (this.root.no == no)
                {
                    root = null;
                }
                else
                {
                    root.DelNode(no);
                }
            }
            else
            {
                Console.WriteLine("空树不能删除！");
            }
        }
    }
    class HeroNode2
    {
        public int no;
        private string name;
        public HeroNode2 left;
        public HeroNode2 right;
        //0:左子树，1：前驱节点
        public int leftType;
        //0:右子树，1：后继节点
        public int rightType;
        public HeroNode2(int no, string name)
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
        public HeroNode2 PreOrderSearch(int no)
        {
            if (this.no == no)
            {
                return this;
            }
            HeroNode2 resNode = null;
            if (this.left != null)
            {
                resNode = this.left.PreOrderSearch(no);
            }
            if (resNode != null)
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
        public HeroNode2 InfixOrderSearch(int no)
        {
            HeroNode2 resNode = null;
            if (this.left != null)
            {
                resNode = this.left.InfixOrderSearch(no);
            }
            if (resNode != null)
            {
                return resNode;
            }
            if (this.no == no)
            {
                return this;
            }
            if (this.right != null)
            {
                resNode = this.right.InfixOrderSearch(no);
            }
            return resNode;
        }

        // 后序查找
        public HeroNode2 PostOrderSearch(int no)
        {
            HeroNode2 resNode = null;
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

        // 删除节点（叶子节点直接删除，非叶子节点删子树）
        public void DelNode(int no)
        {
            if (this.left != null && this.left.no == no)
            {
                this.left = null;
                return;
            }

            if (this.right != null && this.right.no == no)
            {
                this.right = null;
                return;
            }

            if (this.left != null)
            {
                this.left.DelNode(no);
            }
            if (this.right != null)
            {
                this.right.DelNode(no);
            }
        }
    }
}
