using System;
using System.Collections.Generic;
using System.Text;

namespace DataStruct.Stack
{
    public class PolandNotation
    {
        public static void Main(string[] args)
        {
            string expression = "1+((2+3)*4)-5";
            List<string> infixExpressionList = ToInfixExpressionList(expression);


            // 定义逆波兰表达式,为了方便，数字和符号用空格隔开
            // （3+4）*5-6   =》 3 4 + 5 * 6 - 
            //string suffixExpression = "3 4 + 5 * 6 - ";
            //List<string> rpnList = GetListString(suffixExpression);
            //int res = Calculate(rpnList);
            //Console.WriteLine("计算结果="+res);
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
                // 多位数匹配
                //if (item.matches("\\d+"))
                //{
                //    stack.Push(item);
                //}
                //else
                //{
                //    int num1 = int.Parse(stack.Pop());
                //    int num2 = int.Parse(stack.Pop());
                //    int res = 0;
                //    if (item.Equals("+"))
                //    {
                //        res = num1 + num2;
                //    }else if (item.Equals("-"))
                //    {
                //        res = num1 - num2;
                //    }else if (item.Equals("*"))
                //    {
                //        res = num1 * num2;
                //    }else if (item.Equals("/"))
                //    {
                //        res = num1 / num2;
                //    }
                //    else
                //    {
                //        throw new Exception("运算符有误！");
                //    }
                //    stack.Push(res.ToString());
                //}
            }
            return int.Parse(stack.Pop());
        }
    }
}
