using System;
using System.Collections.Generic;
using System.Text;

namespace DataStruct.BinarySortTree
{
    public class BinarySortTreeDemo
    {
        public static void Test()
        {
            int[] arr = {7,3,10,12,5,1,9,2};
            BinarySortTree bst = new BinarySortTree();
            for (int i = 0; i < arr.Length; i++)
            {
                bst.Add(new Node(arr[i]));
            }
            Console.WriteLine("中序遍历二叉排序树");
            bst.InfixOrder();

            Console.WriteLine("删除叶子节点：");
            //bst.DeleteNode(2);// 删除叶子节点
            //bst.DeleteNode(5);// 删除叶子节点
            //bst.DeleteNode(9);// 删除叶子节点
            //bst.DeleteNode(12);// 删除叶子节点
            //bst.DeleteNode(1);// 删除一个子节点
            bst.DeleteNode(7);// 删除两个子节点
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

        // 查找要删除的节点
        public Node Search(int value)
        {
            if(root == null)
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
            while(target.left != null)
            {
                target = target.left;
            }
            // target 就是最小节点,删除
            DeleteNode(target.value);
            return target.value;
        }

        public void DeleteNode(int value)
        {
            if(root == null)
            {
                return;
            }
            else
            {
                // 查找要删除的节点
                Node targetNode = Search(value);
                if(targetNode == null)
                {
                    return;
                }
                // 如果targetNode 就是根节点
                if(root.left == null && root.right == null)
                {
                    root = null;
                    return;
                }
                //查找 targetNode 的父节点
                Node parent = SearchParent(value);
                // 删除的是叶子节点
                if(targetNode.left == null && targetNode.right == null)
                {
                    if(parent.left != null && parent.left.value == value)
                    {
                        parent.left = null;
                    }else if(parent.right != null && parent.right.value == value)
                    {
                        parent.right = null;
                    }
                }else if (targetNode.left != null && targetNode.right != null)
                {
                    // 删除两个子节点的节点
                    int minVal = DeleteRightTreeMin(targetNode.right);
                    targetNode.value = minVal;
                }
                else
                {
                    // 删除只有一个子节点的节点 是有左子节点
                    if(targetNode.left != null)
                    {
                        // targetNode 是左子节点
                        if(parent.left .value == value)
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
                        // 删除的节点只有一个右子节点
                        if(parent.left.value == value)
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
                }
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

        // 查找需要删除的节点
        public Node Search(int value)
        {
            if(value == this.value)
            {
                return this;
            }else if(value < this.value)
            {
                // 左子树查找
                if(this.left == null)
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
            if((this.left!= null && this.left.value == value)||(this.right != null && this.right.value == value))
            {
                return this;
            }
            else
            {
                if(value < this.value && this.left != null)
                {
                    return this.left.SearchParent(value);
                }
                else if(value >= this.value && this.right != null)
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
