using System;
using System.Collections.Generic;
using System.Text;

namespace DataStruct.Queue
{
    public class ArrayQueueDemo
    {
        static void Main(string[] args)
        {
            ArrayQueue aq = new ArrayQueue(3);
            aq.Enqueue(1);
            aq.Enqueue(2);
            aq.Enqueue(3);
            aq.Dequeue();
            Console.WriteLine( aq.Head());
            aq.Dequeue();
            aq.Dequeue();
            aq.Enqueue(100);
            aq.Enqueue(100);
            aq.Enqueue(100);
            aq.Show();
        }
    }

    // 使用数组模拟队列
    class ArrayQueue
    {
        private int maxSize; //表示数组最大容量
        private int front; // 队列头
        private int rear;//队列尾
        private int[] arr;//该数组用于存放数据

        public ArrayQueue(int arrMaxSize)
        {
            maxSize = arrMaxSize;
            arr = new int[maxSize];
            front = 0; // 指向队列的头部元素
            rear = 0;// 指向队列尾部元素的后一个位置
        }

        /// <summary>
        /// 判断队列是否满了
        /// </summary>
        /// <returns></returns>
        public bool isFull()
        {
            return rear == maxSize;
        }

        /// <summary>
        /// 判断队列是否为空
        /// </summary>
        /// <returns></returns>
        public bool isEmpty()
        {
            return rear == front;
        }

        /// <summary>
        /// 添加数据到队列，入队
        /// </summary>
        /// <param name="n"></param>
        public void Enqueue(int n)
        {
            if (isFull())
            {
                if(front == 0)
                {
                    Console.WriteLine("队列满了，不能添加数据");
                    return;
                }
                else
                {
                    // 当尾指针指向末尾且有空位，尝试搬移数据，让队列重复使用
                    if (rear == maxSize)
                    {
                        for (int i = 0; i < rear - front; i++)
                        {
                            arr[i] = arr[front + i];
                        }
                        rear = rear - front;
                        front = 0;
                    }
                }
            }
            arr[rear] = n;
            rear++;
        }

        /// <summary>
        /// 获取队列的数据，出队
        /// </summary>
        /// <returns></returns>
        public int Dequeue()
        {
            if (isEmpty())
            {
                throw new Exception("队列空，无法取数据！");
            }

            int target = arr[front];
            front++;
            return target;
        }

        /// <summary>
        /// 显示队列里的所有数据
        /// </summary>
        public void Show()
        {
            if (isEmpty())
            {
                Console.WriteLine("队列是空的，没有数据！");
                return;
            }

            for (int i = front; i < rear; i++)
            {
                Console.WriteLine(arr[i]);
            }

        }

        /// <summary>
        /// 显示队列的头数据，注意不是取出数据
        /// </summary>
        /// <returns></returns>
        public int Head()
        {
            if (isEmpty())
            {
                throw new Exception("队列空，无法取数据！");
            }
            return arr[front];
        }

    }
}
