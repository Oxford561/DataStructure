using System;
using System.Collections.Generic;
using System.Text;

namespace DataStruct.Queue
{
    public class CircleArrayQueueDemo
    {
        public static void Test()
        {
            CircleArrayQueue aq = new CircleArrayQueue(4);
            aq.Enqueue(1);
            aq.Enqueue(2);
            aq.Enqueue(3);
            aq.Show();
            aq.Dequeue();
            aq.Show();
            //Console.WriteLine(aq.Head());
            aq.Dequeue();
            aq.Show();
            aq.Dequeue();
            aq.Show();
            aq.Enqueue(100);
            aq.Enqueue(100);
            aq.Enqueue(100);
            aq.Enqueue(100);
            aq.Show();
        }
    }

    // 使用数组模拟环形队列
    class CircleArrayQueue
    {
        private int maxSize; //表示数组最大容量
        private int front; // 队列头
        private int rear;//队列尾
        private int[] arr;//该数组用于存放数据

        public CircleArrayQueue(int arrMaxSize)
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
            return (rear+1)%maxSize == front;
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
                Console.WriteLine("队列满了，不能添加数据");
                return;
            }
            arr[rear] = n;
            rear = (rear+1) % maxSize;
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
            front = (front + 1) % maxSize;
            return target;
        }

        /// <summary>
        /// 显示队列里的所有数据
        /// </summary>
        public void Show()
        {
            Console.WriteLine("遍历队列数据：");
            if (isEmpty())
            {
                Console.WriteLine("队列是空的，没有数据！");
                return;
            }

            for (int i = front; i < front + Size(); i++)
            {
                Console.WriteLine(i%maxSize+" "+arr[i%maxSize]);
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

        public int Size()
        {
            return (rear - front + maxSize) % maxSize;
        }

    }
}
