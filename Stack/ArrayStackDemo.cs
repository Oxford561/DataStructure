using System;
using System.Collections.Generic;
using System.Text;

namespace DataStruct.Stack
{
    public class ArrayStackDemo
    {
        static void Main(string[] args)
        {
            ArrayStack stack = new ArrayStack(5);
            Console.WriteLine(stack.IsEmpty());
            stack.Show();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            //Console.WriteLine(stack.Pop());
            stack.Show();
            Console.WriteLine(stack.IsFull());
            stack.Push(6);
        }
    }

    class ArrayStack
    {
        private int maxSize;
        private int[] stack;
        private int top = -1;

        public ArrayStack(int maxSize)
        {
            this.maxSize = maxSize;
            stack = new int[this.maxSize];
        }

        public bool IsFull()
        {
            return top == maxSize - 1;
        }

        public bool IsEmpty()
        {
            return top == -1;
        }

        public void Push(int value)
        {
            if (IsFull())
            {
                Console.WriteLine("栈满了！");
                return;
            }

            top++;
            stack[top] = value;
        }

        public int Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("栈空了！");
            }

            int value = stack[top];
            top--;
            return value;
        }

        public void Show()
        {
            if (IsEmpty())
            {
                Console.WriteLine("栈空了！");
                return;
            }

            for (int i = top; i>=0; i--)
            {
                Console.WriteLine(stack[i]);
            }
        }
    }
}
