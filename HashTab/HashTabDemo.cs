using System;
using System.Collections.Generic;
using System.Text;

namespace DataStruct.HashTab
{
    public class HashTabDemo
    {
        public static void Test()
        {
            HashTab hashTab = new HashTab(7);
            Emp emp1 = new Emp(1, "one");
            Emp emp2 = new Emp(2, "two");
            Emp emp3 = new Emp(3, "three");
            hashTab.Add(emp1);
            hashTab.Add(emp2);
            hashTab.Add(emp3);
            hashTab.List();
            hashTab.FindEmpById(3);
        }
    }

    //创建哈希表
    class HashTab
    {
        private EmpLinkedList[] empLinkedListArray;
        private int size;
        public HashTab(int size)
        {
            this.size = size;
            empLinkedListArray = new EmpLinkedList[size];
            for (int i = 0; i < size; i++)
            {
                empLinkedListArray[i] = new EmpLinkedList();
            }
        }

        public void Add(Emp emp)
        {
            int empLinkedListNo = HashFun(emp.id);
            empLinkedListArray[empLinkedListNo].Add(emp);
        }

        public void List()
        {
            for (int i = 0; i < size; i++)
            {
                empLinkedListArray[i].List();
            }
        }

        public void FindEmpById(int id)
        {
            int no = HashFun(id);
            Emp emp = empLinkedListArray[no].FindEmpById(id);
            if(emp != null)
            {
                Console.WriteLine("找到该雇员在"+(no+1)+"条链表中");
            }
            else
            {
                Console.WriteLine("在哈希表中没有找到该雇员");
            }
        }

        public int HashFun(int id)
        {
            return id % size;
        }
    }

    class Emp
    {
        public int id;
        public string name;
        public Emp next;

        public Emp() { }
        public Emp(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }

    class EmpLinkedList
    {
        // 头指针指向第一个 Emp
        private Emp head;

        //尾插法
        public void Add(Emp emp)
        {
            if(head == null)
            {
                head = emp;
                return;
            }

            Emp cur = head;
            while(cur.next != null)
            {
                cur = cur.next;
            }
            cur.next = emp;
        }

        public void List()
        {
            if(head == null)
            {
                Console.WriteLine("当前链表为空");
                return;
            }
            Console.WriteLine("当前链表的数据是：");
            Emp cur = head;
            while (cur!= null)
            {
                Console.Write(cur.id + ":" + cur.name);
                cur = cur.next;
            }
            Console.WriteLine();
        }

        public Emp FindEmpById(int id)
        {
            if(head == null)
            {
                Console.WriteLine("链表为空");
                return null;
            }

            Emp cur = head;
            while(cur.id != id)
            {
                if(cur.next == null)
                {
                    cur = null;
                    break;
                }
                cur = cur.next;
            }
            return cur;
        }
    }
}
