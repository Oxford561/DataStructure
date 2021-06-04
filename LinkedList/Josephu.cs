using System;
using System.Collections.Generic;
using System.Text;

namespace DataStruct.LinkedList
{
    public class Josephu
    {
        static void Main(string[] args)
        {
            CircleSingleLinkedList csll = new CircleSingleLinkedList();
            csll.AddBoy(5);
            csll.ShowBoy();
        }
    }

    // 循环单链表
    class CircleSingleLinkedList
    {
        private Boy first = new Boy();
        public void AddBoy(int num)
        {
            if(num < 1)
            {
                Console.WriteLine("num 的值不正确");
                return;
            }

            Boy curBoy = null;
            for (int i = 1; i <= num; i++)
            {
                Boy boy = new Boy(i);
                if(i == 1)
                {
                    first = boy;
                    first.next = first;
                    curBoy = first;
                }
                else
                {
                    curBoy.next = boy;
                    boy.next = first;
                    curBoy = boy;
                }
            }
        }

        public void ShowBoy()
        {
            if(first == null)
            {
                Console.WriteLine("链表为空！");
                return;
            }
            Boy curBoy = first;
            while(true)
            {
                Console.WriteLine(curBoy.no);
                if(curBoy.next == first)
                {
                    break;
                }
                curBoy = curBoy.next;
            }
        }
    }

    class Boy
    {
        public int no;
        public Boy next;
        public Boy() { }
        public Boy(int no)
        {
            this.no = no;
        }
    }
}
