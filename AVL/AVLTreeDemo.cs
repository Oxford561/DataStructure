using System;
using System.Collections.Generic;
using System.Text;

namespace DataStruct.AVL
{
    public class AVLTreeDemo
    {
        public static void Test()
        {
            int[] arr = {4,3,6,5,7,8 };
            AVLTree avlt = new AVLTree();
            for (int i = 0; i < arr.Length; i++)
            {
                avlt.Add(new Node(arr[i]));
            }

            Console.WriteLine("中序遍历：");
            avlt.InfixOrder();
            Console.WriteLine("平衡处理后");
            Console.WriteLine("树的高度："+avlt.root.Height());
            Console.WriteLine("左子树的高度：" + avlt.root.LeftHeight());
            Console.WriteLine("右子树的高度：" + avlt.root.RightHeight());
        }
    }


    public class AVLTree
    {
        public Node root;
        public void Add(Node node)
        {
            if (root == null)
            {
                root = node;
            }
            else
            {
                root.Add(node);
            }
        }

        public void InfixOrder()
        {
            if (root != null)
            {
                root.InfixOrder();
            }
            else
            {
                Console.WriteLine("二叉排序树为空，不能遍历");
            }
        }

        // 查找要删除的节点
        public Node Search(int value)
        {
            if (root == null)
            {
                return null;
            }
            else
            {
                return root.Search(value);
            }
        }

        // 查找父节点
        public Node SearchParent(int value)
        {
            if (root == null)
            {
                return null;
            }
            else
            {
                return root.SearchParent(value);
            }
        }

        // 拿到要删除节点的右子节点下最小的节点值
        public int DeleteRightTreeMin(Node node)
        {
            Node target = node;
            // 循环查找左节点，找到最小值
            while (target.left != null)
            {
                target = target.left;
            }
            // target 就是最小节点,删除
            DeleteNode(target.value);
            return target.value;
        }

        public void DeleteNode(int value)
        {
            if (root == null)
            {
                return;
            }
            else
            {
                // 查找要删除的节点
                Node targetNode = Search(value);
                if (targetNode == null)
                {
                    return;
                }
                // 如果targetNode 就是根节点
                if (root.left == null && root.right == null)
                {
                    root = null;
                    return;
                }
                //查找 targetNode 的父节点
                Node parent = SearchParent(value);
                // 删除的是叶子节点
                if (targetNode.left == null && targetNode.right == null)
                {
                    if (parent.left != null && parent.left.value == value)
                    {
                        parent.left = null;
                    }
                    else if (parent.right != null && parent.right.value == value)
                    {
                        parent.right = null;
                    }
                }
                else if (targetNode.left != null && targetNode.right != null)
                {
                    // 删除两个子节点的节点
                    int minVal = DeleteRightTreeMin(targetNode.right);
                    targetNode.value = minVal;
                }
                else
                {
                    // 删除只有一个子节点的节点 是有左子节点
                    if (targetNode.left != null)
                    {
                        if (parent != null)
                        {
                            // targetNode 是左子节点
                            if (parent.left.value == value)
                            {
                                parent.left = targetNode.left;
                            }
                            else
                            {
                                // targetNode 是右子节点
                                parent.right = targetNode.left;
                            }
                        }
                        else
                        {
                            // 如果删除的是只有一个左子节点的根节点
                            root = targetNode.left;
                        }
                    }
                    else
                    {
                        if (parent != null)
                        {
                            // 删除的节点只有一个右子节点
                            if (parent.left.value == value)
                            {
                                // targetNode 是左子节点
                                parent.left = targetNode.right;
                            }
                            else
                            {
                                // targetNode 是右子节点
                                parent.right = targetNode.right;
                            }
                        }
                        else
                        {
                            // 如果删除的是只有一个右子节点的根节点
                            root = targetNode.right;
                        }
                    }
                }
            }
        }
    }

    public class Node
    {
        public int value;
        public Node left;
        public Node right;

        public Node(int value)
        {
            this.value = value;
        }

        // 当前节点左子树高度
        public int LeftHeight()
        {
            if(left == null)
            {
                return 0;
            }
            return left.Height();
        }

        // 当前节点右子树高度
        public int RightHeight()
        {
            if (right == null)
            {
                return 0;
            }
            return right.Height();
        }

        //返回以当前节点为根节点的树的高度
        public int Height()
        {
            return Math.Max(left == null ? 0 : left.Height(), right == null ? 0 : right.Height()) + 1;
        }

        // 左旋转
        public void LeftRotate()
        {
            // 创建新的节点赋予当前根节点的值
            Node newNode = new Node(value);
            //新的的节点的左子树设置成当前节点的左子树
            newNode.left = left;
            //新的节点的右子树设置成当前节点的右子树的左子树
            newNode.right = right.left;
            // 把当前节点的值替换成右子节点的值
            value = right.value;
            // 把当前节点的右子树设置成当前节点的右子节点的右子节点
            right = right.right;
            // 把当前节点的左子树（左子节点）设置成新的节点
            left = newNode;
        }

        // 查找需要删除的节点
        public Node Search(int value)
        {
            if (value == this.value)
            {
                return this;
            }
            else if (value < this.value)
            {
                // 左子树查找
                if (this.left == null)
                {
                    return null;
                }

                return this.left.Search(value);
            }
            else
            {
                // 右子树查找
                if (this.right == null)
                {
                    return null;
                }

                return this.right.Search(value);
            }
        }

        // 查找删除节点的父节点
        public Node SearchParent(int value)
        {
            if ((this.left != null && this.left.value == value) || (this.right != null && this.right.value == value))
            {
                return this;
            }
            else
            {
                if (value < this.value && this.left != null)
                {
                    return this.left.SearchParent(value);
                }
                else if (value >= this.value && this.right != null)
                {
                    return this.right.SearchParent(value);
                }
                else
                {
                    return null;
                }
            }
        }

        public override string ToString()
        {
            return "Node[value=" + value + "]";
        }

        // 添加节点,满足二叉排序树
        public void Add(Node node)
        {
            if (node == null)
            {
                return;
            }

            //传入节点和当前子树的根节点进行比较
            if (node.value < this.value)
            {
                if (this.left == null)
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
                if (this.right == null)
                {
                    this.right = node;
                }
                else
                {
                    this.right.Add(node);
                }
            }

            // 添加完，(右子树高度-左子树高度) > 1  左旋转
            if((RightHeight() - LeftHeight()) > 1)
            {
                if(right != null && right.RightHeight() > right.LeftHeight())
                {
                    LeftRotate();
                }
            }
        }

        public void InfixOrder()
        {
            if (this.left != null)
            {
                this.left.InfixOrder();
            }
            Console.WriteLine(this);
            if (this.right != null)
            {
                this.right.InfixOrder();
            }
        }
    }
}
