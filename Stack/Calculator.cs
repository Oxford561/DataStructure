using System;
using System.Collections.Generic;
using System.Text;

namespace DataStruct.Stack
{
    public class Calculator
    {
        public static void Main(string[] args)
        {
            string expression = "8+2*6-2";
            ArrayStack2 numStack = new ArrayStack2(10);
            ArrayStack2 operStack = new ArrayStack2(10);
            int index = 0;
            char ch;
            int oper;
            int num1;
            int num2;
            int res;
            while (true)
            {
                string flag = expression.Substring(index, 1);
                ch = Char.Parse(flag);
                if (operStack.IsOper(ch))
                {
                    if (!operStack.IsEmpty())
                    {
                        if (operStack.Priority(ch) <= operStack.Priority(operStack.Peek()))
                        {
                            num1 = numStack.Pop();
                            num2 = numStack.Pop();
                            oper = operStack.Pop();
                            res = numStack.Cal(num1, num2, oper);
                            numStack.Push(res);
                            operStack.Push(ch);
                        }
                        else
                        {
                            operStack.Push(ch);
                        }
                    }
                    else
                    {
                        operStack.Push(ch);
                    }
                }
                else
                {
                    numStack.Push((int)Char.GetNumericValue(ch));
                }
                index++;
                if (index >= expression.Length)
                {
                    break;
                }
            }

            while (true)
            {
                if (operStack.IsEmpty())
                {
                    break;
                }
                num1 = numStack.Pop();
                num2 = numStack.Pop();
                oper = operStack.Pop();
                res = numStack.Cal(num1, num2, oper);
                numStack.Push(res);
            }

            Console.WriteLine(expression + " = " + numStack.Pop());
        }
    }

    class ArrayStack2
    {
        private int maxSize;
        private int[] stack;
        private int top = -1;

        public ArrayStack2(int maxSize)
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

            for (int i = top; i >= 0; i--)
            {
                Console.WriteLine(stack[i]);
            }
        }

        public int Priority(int oper)
        {
            if (oper == '*' || oper == '/')
            {
                return 1;
            }
            else if (oper == '+' || oper == '-')
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        public bool IsOper(int val)
        {
            return val == '+' || val == '-' || val == '*' || val == '/';
        }

        public int Cal(int num1, int num2, int oper)
        {
            int res = 0;
            switch (oper)
            {
                case '+':
                    res = num1 + num2;
                    break;
                case '-':
                    res = num2 - num1;
                    break;
                case '*':
                    res = num1 * num2;
                    break;
                case '/':
                    res = num2 / num1;
                    break;
            }
            return res;
        }

        public int Peek()
        {
            return stack[top];
        }
    }
}
