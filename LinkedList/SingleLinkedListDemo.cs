using System;
using System.Collections.Generic;
using System.Text;

namespace DataStruct.LinkedList
{
    public class SingleLinkedListDemo
    {
        static void Main(string[] args)
        {
            HeroNode node1 = new HeroNode(1, "宋江", "及时雨");
            HeroNode node2 = new HeroNode(2, "卢俊义", "玉麒麟");
            HeroNode node3 = new HeroNode(3, "吴用", "智多星");
            HeroNode node4 = new HeroNode(4, "林冲", "豹子头");

            SingleLinkedList sll = new SingleLinkedList();
            //sll.InsertTail(node1);
            //sll.InsertTail(node2);
            //sll.InsertTail(node3);
            //sll.InsertTail(node4);

            sll.InsertByOrder(node1);
            sll.InsertByOrder(node4);
            sll.InsertByOrder(node2);
            sll.InsertByOrder(node3);

            sll.Update(new HeroNode(3,"小林冲", "豹子头"));
            sll.Delete(4);
            sll.Show();
            Console.WriteLine("单链表的长度："+ sll.Size());
        }
    }

    // 单链表
    class SingleLinkedList
    {
        private HeroNode head = new HeroNode();

        public void InsertTail(HeroNode heroNode)
        {
            HeroNode temp = head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            temp.next = heroNode;
        }

        public void InsertByOrder(HeroNode heroNode)
        {
            HeroNode temp = head;
            bool flag = false;
            while(temp.next != null)
            {
                if(temp.next.no > heroNode.no)
                {
                    break;
                }else if (temp.next.no == heroNode.no)
                {
                    flag = true;
                    break;
                }
                temp = temp.next;
            }
            if (flag)
            {
                Console.WriteLine("准备插入的英雄的编号已经存在！");
            }
            else
            {
                heroNode.next = temp.next;
                temp.next = heroNode;
            }
        }

        public void Update(HeroNode newHeroNode)
        {
            if (head.next == null)
            {
                Console.WriteLine("链表为空！");
                return;
            }
            HeroNode temp = head.next;
            bool flag = false;
            while (temp != null)
            {
                if(temp.no == newHeroNode.no)
                {
                    flag = true;
                    break;
                }
                temp = temp.next;
            }
            if (flag)
            {
                temp.name = newHeroNode.name;
                temp.nickName = newHeroNode.nickName;
            }
            else
            {
                Console.WriteLine("没有找到对应结点！");
            }
        }

        public void Delete(int no)
        {
            if (head.next == null)
            {
                Console.WriteLine("链表为空！");
                return;
            }
            HeroNode temp = head;
            bool flag = false;
            while(temp.next != null)
            {
                if(temp.next.no == no)
                {
                    flag = true;
                    break;
                }
                temp = temp.next;
            }
            if (flag)
            {
                temp.next = temp.next.next;
            }
            else
            {
                Console.WriteLine("没有找到对应结点！");
            }
        }

        /// <summary>
        /// 获取单链表的长度
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            if (head.next == null)
            {
                Console.WriteLine("链表为空！");
                return 0;
            }

            HeroNode temp = head;
            int count = 0;
            while(temp.next != null)
            {
                count++;
                temp = temp.next;
            }
            return count;
        }

        public void Show()
        {
            if(head.next == null)
            {
                Console.WriteLine("链表为空！");
                return;
            }
            HeroNode temp = head.next;
            while (temp != null)
            {
                Console.WriteLine(temp);
                temp = temp.next;
            }
        }
    }

    class HeroNode
    {
        public int no;
        public string name;
        public string nickName;
        public HeroNode next;

        public HeroNode() { }
        public HeroNode(int no,string name,string nickName)
        {
            this.no = no;
            this.name = name;
            this.nickName = nickName;
        }

        public override string ToString()
        {
            return "HeroNode [no=" + no + ",name=" + name + ",nickName=" + nickName+"]";
        }
    }
}
