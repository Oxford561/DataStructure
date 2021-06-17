using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DataStruct.Stack
{
    public class PolandNotation
    {
        public static void Test()
        {
            string expression = "1+((2+3)*4)-5";
            List<string> infixExpressionList = ToInfixExpressionList(expression);
            List<string> parseSuffixExpressionList = ParseSuffixExpressionList(infixExpressionList);
            int res = Calculate(parseSuffixExpressionList);
            Console.WriteLine("1+((2+3)*4)-5=" + res);
            // 定义逆波兰表达式,为了方便，数字和符号用空格隔开
            // （3+4）*5-6   =》 3 4 + 5 * 6 - 
            //string suffixExpression = "3 4 + 5 * 6 -";
            //List<string> rpnList = GetListString(suffixExpression);
            //int res = Calculate(rpnList);
            //Console.WriteLine("（3+4）*5-6 =" + res);
        }

        public static List<string> ParseSuffixExpressionList(List<string> ls)
        {
            Stack<string> s1 = new Stack<string>();
            List<string> s2 = new List<string>();
            foreach (var item in ls)
            {
                if (IsNumberic(item))
                {
                    s2.Add(item);
                }else if (item.Equals("("))
                {
                    s1.Push(item);
                }else if (item.Equals(")"))
                {
                    while (!s1.Peek().Equals("("))
                    {
                        s2.Add(s1.Pop());
                    }
                    s1.Pop();//将 ( 弹出 消除括号
                }
                else
                {
                    // 当 item的优先级小于等于 s1栈顶运算符
                    // 弹出s1 栈顶运算符加入s2
                    while(s1.Count != 0 && GetProtor(item) <= GetProtor(s1.Peek()))
                    {
                        s2.Add(s1.Pop());
                    }
                    s1.Push(item);
                }
            }

            while(s1.Count != 0)
            {
                s2.Add(s1.Pop());
            }

            return s2;
        }

        public static int GetProtor(string operation)
        {
            int res = 0;
            switch (operation)
            {
                case "+":
                    res = 1;
                    break;
                case "-":
                    res = 1;
                    break;
                case "*":
                    res = 2;
                    break;
                case "/":
                    res = 2;
                    break;
                default:
                    Console.WriteLine("不存在该运算符");
                    break;
            }
            return res;
        }

        // 将中缀表达式转成对于的list
        public static List<string> ToInfixExpressionList(string s)
        {
            List<string> ls = new List<string>();
            int i = 0;
            string str = "";
            char c;
            do
            {
                c = s.ToCharArray()[i];
                if (c < 48 || c > 57)
                {
                    // 运算符处理
                    ls.Add("" + c);
                    i++;
                }
                else
                {
                    // 数字处理
                    str = "";
                    while (i < s.Length && (s.ToCharArray()[i] >= 48 && s.ToCharArray()[i] <= 57))
                    {
                        str += c;
                        i++;
                    }
                    ls.Add(str);
                }
            } while (i < s.Length);
            return ls;
        }

        // 将逆波兰表达式 转成 list
        public static List<string> GetListString(string expression)
        {
            string[] split = expression.Split(" ");
            List<string> list = new List<string>();
            foreach (var item in split)
            {
                list.Add(item);
            }
            return list;
        }

        public static int Calculate(List<string> lst)
        {
            Stack<string> stack = new Stack<string>();
            foreach (string item in lst)
            {
                //多位数匹配
                if (IsNumberic(item))
                {
                    stack.Push(item);
                }
                else
                {
                    int num1 = int.Parse(stack.Pop());
                    int num2 = int.Parse(stack.Pop());
                    int res = 0;
                    if (item.Equals("+"))
                    {
                        res = num1 + num2;
                    }
                    else if (item.Equals("-"))
                    {
                        res = num2 - num1;
                    }
                    else if (item.Equals("*"))
                    {
                        res = num1 * num2;
                    }
                    else if (item.Equals("/"))
                    {
                        res = num1 / num2;
                    }
                    else
                    {
                        throw new Exception("运算符有误！");
                    }
                    stack.Push(res.ToString());
                }
            }
            return int.Parse(stack.Pop());
        }


        public static bool IsNumberic(string oText)
        {
            try
            {
                int var1 = Convert.ToInt32(oText);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }


}
