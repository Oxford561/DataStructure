using System;
using System.Collections.Generic;
using System.Text;

namespace DataStruct.Graph
{
    public class Graph
    {
        private List<string> vertexList;//存储顶点集合
        private int[,] edges;//存储图对应的邻接矩阵
        private int numOfEdges;// 表示边的数量

        public Graph(int num)
        {
            this.numOfEdges = 0;
            edges = new int[num, num];
            vertexList = new List<string>(num);
        }

        //图中常用的方法
        // 得到图的顶点个数
        public int GetNumOfVertex()
        {
            return vertexList.Count;
        }

        // 获取边的数量
        public int GetNumOfEdges()
        {
            return numOfEdges;
        }

        // 返回顶点的下标数据
        public String GetValueByIndex(int i)
        {
            return vertexList[i];
        }

        // 返回坐标的权值
        public int GetWeight(int v1, int v2)
        {
            return edges[v1, v2];
        }

        public void Show()
        {
            foreach (var item in edges)
            {
                Console.WriteLine(item);
            }
        }

        // 插入节点
        public void InsertVertex(string vertex)
        {
            vertexList.Add(vertex);
        }


        /// <summary>
        /// 添加边
        /// </summary>
        /// <param name="v1">x</param>
        /// <param name="v2">y</param>
        /// <param name="weight"></param>
        public void InsertEdge(int v1,int v2,int weight)
        {
            edges[v1, v2] = weight;
            edges[v2, v1] = weight;
            numOfEdges++;
        }
        public static void Test()
        {
            int n = 5;
            string[] vertexs = { "A", "B", "C", "D", "E" };
            Graph graph = new Graph(n);
            foreach (var item in vertexs)
            {
                graph.InsertVertex(item);
            }
            // A-B A-C B-C B-D B-E
            graph.InsertEdge(0,1,1);// A-B
            graph.InsertEdge(0, 2, 1);//A-C
            graph.InsertEdge(1, 2, 1);//B-C 
            graph.InsertEdge(1, 3, 1);// B-D
            graph.InsertEdge(1, 4, 1);//B-E

            graph.Show();
        }
    }
}
