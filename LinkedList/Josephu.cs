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
            //csll.ShowBoy();
            csll.CountBoy(1, 2, 5);
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

        /// <summary>
        /// 约瑟夫算法
        /// </summary>
        /// <param name="startNo">表示从第几个小孩开始数数</param>
        /// <param name="countNum">表示数几下</param>
        /// <param name="num">表示最初有多少小孩在圈中</param>
        public void CountBoy(int startNo,int countNum,int num)
        {
            if(first == null || startNo < 1 || startNo > num)
            {
                Console.WriteLine("参数输入有误，请重新输入");
                return;
            }
            // 将helper 指针指向first的前面
            Boy helper = first;
            while (helper.next != first)
            {
                helper = helper.next;
            }
            // 报数前移动到k-1 次的位置上
            for (int i = 0; i < startNo - 1; i++)
            {
                first = first.next;
                helper = helper.next;
            }
            // 开始报数 helper 和 first 同时移动到需要出圈的小孩位置上
            while(helper != first)
            {
                for (int i = 0; i < countNum - 1; i++)
                {
                    first = first.next;
                    helper = helper.next;
                }
                Console.WriteLine("出圈序列："+first.no);
                first = first.next;
                helper.next = first;
            }
            Console.WriteLine("出圈序列：" + first.no);
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
