using System;
using System.Collections.Generic;
using System.Text;

namespace DataStruct.LinkedList
{
    public class DoubleLinkedListDemo
    {
        static void Main(string[] args)
        {
            HeroNode2 node1 = new HeroNode2(1, "宋江", "及时雨");
            HeroNode2 node2 = new HeroNode2(2, "卢俊义", "玉麒麟");
            HeroNode2 node3 = new HeroNode2(3, "吴用", "智多星");
            HeroNode2 node4 = new HeroNode2(4, "林冲", "豹子头");

            DoubleLinkedList dll = new DoubleLinkedList();
            dll.InsertTail(node1);
            dll.InsertTail(node2);
            dll.InsertTail(node3);
            dll.InsertTail(node4);
            dll.Show();

            HeroNode2 newHeroNode = new HeroNode2(4, "公孙胜", "润云龙");
            dll.Update(newHeroNode);
            dll.Show();

            dll.Delete(3);
            dll.Show();
        }
    }

    class DoubleLinkedList
    {
        private HeroNode2 head = new HeroNode2();

        public void InsertTail(HeroNode2 heroNode)
        {
            HeroNode2 temp = head;
            while (temp.next != null)
            {
                temp = temp.next;
            }

            temp.next = heroNode;
            heroNode.pre = temp;
        }

        public void Update(HeroNode2 newHeroNode)
        {
            if (head.next == null)
            {
                Console.WriteLine("链表为空！");
                return;
            }
            HeroNode2 temp = head.next;
            bool flag = false;
            while (temp != null)
            {
                if (temp.no == newHeroNode.no)
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
            HeroNode2 temp = head.next;
            bool flag = false;
            while (temp != null)
            {
                if (temp.no == no)
                {
                    flag = true;
                    break;
                }
                temp = temp.next;
            }
            if (flag)
            {
                temp.pre.next = temp.next;
                if(temp.next != null)
                {
                    temp.next.pre = temp.pre;
                }
            }
            else
            {
                Console.WriteLine("没有找到对应结点！");
            }
        }

        public void Show()
        {
            if (head.next == null)
            {
                Console.WriteLine("链表为空！");
                return;
            }
            HeroNode2 temp = head.next;
            while (temp != null)
            {
                Console.WriteLine(temp);
                temp = temp.next;
            }
        }

    }

    class HeroNode2
    {
        public int no;
        public string name;
        public string nickName;
        public HeroNode2 next;
        public HeroNode2 pre;

        public HeroNode2() { }
        public HeroNode2(int no, string name, string nickName)
        {
            this.no = no;
            this.name = name;
            this.nickName = nickName;
        }

        public override string ToString()
        {
            return "HeroNode2 [no=" + no + ",name=" + name + ",nickName=" + nickName + "]";
        }
    }
}
