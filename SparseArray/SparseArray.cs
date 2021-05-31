using System;
using System.Collections.Generic;
using System.Text;

namespace DataStruct.SparseArray
{
    public class SparseArray
    {
        static void Main(string[] args)
        {
            //创建一个原始的二维数组 11*11
            // 0 :没有棋子，1：黑子  2：蓝子
            int [,] chessArr1 = new int[11,11];
            chessArr1[1,2] = 1;
            chessArr1[2, 3] = 2;
            Console.WriteLine("原始的二维数组：");
            //输出原始的二维数组
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11 ; j++)
                {
                    Console.Write(" "+chessArr1[i, j]);
                }
                Console.WriteLine("");
            }

            // 将二维数组转稀疏数组的思路
            // 1、遍历二维数组，得到非0数据个数
            int sum = 0;
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if(chessArr1[i,j] != 0)
                    {
                        sum++;
                    }
                }
            }

            //2、创建稀疏数组
            int[,] sparseArr = new int[sum + 1, 3];
            //给稀疏数组赋值
            sparseArr[0, 0] = 11;
            sparseArr[0, 1] = 11;
            sparseArr[0, 2] = sum;
            // 遍历二维数组，将非0的数值存放到spareArr中
            int count = 0;//用于记录第几个非0数字
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if(chessArr1[i,j] != 0)
                    {
                        count++;
                        sparseArr[count, 0] = i;
                        sparseArr[count, 1] = j;
                        sparseArr[count, 2] = chessArr1[i, j];
                    }
                }
            }

            //输出稀疏数组
            Console.WriteLine("得到的稀疏数组为：");
            for (int i = 0; i < count+1; i++)
            {
                Console.WriteLine(sparseArr[i,0]+"  "+sparseArr[i,1]+"  "+sparseArr[i,2]);
            }

            //===========================
            // 将稀疏数组恢复成原始的二维数组
            //1、先读取稀疏数组的第一行，获取第一行的数组，创建原始数组
            int[,] chessArr2 = new int[sparseArr[0, 0], sparseArr[0, 1]];

            //2、在读取稀疏数组后几行数据赋予原始的二维数组
            for (int i = 1; i < count+1; i++)
            {
                chessArr2[sparseArr[i, 0], sparseArr[i, 1]] = sparseArr[i, 2];
            }

            //输出恢复后的二维数组
            Console.WriteLine("恢复后的二维数组：");
            for(int i = 0; i < sparseArr[0,0]; i++)
            {
                for (int j = 0; j < sparseArr[0, 1]; j++)
                {
                    Console.Write(" "+chessArr2[i, j]);
                }
                Console.WriteLine();
            }


        }
    }
}
