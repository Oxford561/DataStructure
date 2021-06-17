using System;
using System.Collections.Generic;
using System.Text;

namespace DataStruct.Recursion
{
    public class MiGong
    {
        public static void Test()
        {
            // 创建二维数组迷宫
            int[,] map = new int[8, 7];
            // 1 表示墙体
            for (int i = 0; i < 7; i++)
            {
                map[0, i] = 1;
                map[7, i] = 1;
            }

            for (int i = 0; i < 8; i++)
            {
                map[i, 0] = 1;
                map[i, 6] = 1;
            }
            //设置挡板
            map[3, 1] = 1;
            map[3, 2] = 1;
            ShowMap(map);
            SetWay(map, 1, 1);
            ShowMap(map);
        }

        public static void ShowMap(int[,] map)
        {
            Console.WriteLine("地图的情况：");
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.Write(map[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 使用递归 给小球找路（【1，1】=》【6，5】）下-》右-》上-》左
        /// </summary>
        /// <param name="map">地图</param>
        /// <param name="i">起始点</param>
        /// <param name="j"></param>
        /// <returns>找到通路返回true</returns>
        public static bool SetWay(int[,] map,int i,int j)
        {
            if(map[6,5] == 2)
            {
                return true;
            }
            else
            {
                // 没有走过
                if (map[i, j] == 0)
                {
                    map[i, j] = 2;
                    // 向下走
                    if (SetWay(map, i + 1, j))
                    {
                        return true;
                        // 向右走
                    } else if (SetWay(map, i, j + 1))
                    {
                        return true;
                    }
                    else if (SetWay(map, i - 1, j))
                    {
                        return true;
                    }
                    else if (SetWay(map, i, j - 1))
                    {
                        return true;
                    }
                    else
                    {
                        // 该点死路
                        map[i, j] = 3;
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
