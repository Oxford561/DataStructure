using System;
using System.Collections.Generic;
using System.Text;

namespace DataStruct.Graphs
{
    public class Graph
    {
        private List<string> vertexList;//存储顶点集合
        private int[,] edges;//存储图对应的邻接矩阵
        private int numOfEdges;// 表示边的数量
        private bool[] isVisited;// 顶点是否访问到

        public Graph(int num)
        {
            this.numOfEdges = 0;
            edges = new int[num, num];
            vertexList = new List<string>(num);
            isVisited = new bool[num];
        }

        #region 深度优先算法
        // 根据前一个邻接节点的下标获取下一个邻接节点
        public int GetNextNeighbor(int v1, int v2)
        {
            for (int i = v2 + 1; i < vertexList.Count; i++)
            {
                if (edges[v1, i] > 0)
                {
                    return i;
                }
            }
            return -1;
        }

        // 得到第一个邻接节点的下标
        public int GetFirstNeighbor(int index)
        {
            for (int i = 0; i < vertexList.Count; i++)
            {
                if (edges[index, i] > 0)
                {
                    return i;
                }
            }
            return -1;
        }

        public void DFS(bool[] isVisited,int i)
        {
            // 访问该节点
            Console.Write(GetValueByIndex(i) + "->");
            //将该节点设置为已访问
            isVisited[i] = true;
            // 查找 i 的第一个邻接节点
            int w = GetFirstNeighbor(i);
            // 有邻接节点
            while(w != -1)
            {
                if (!isVisited[w])
                {
                    DFS(isVisited, w);
                }
                // 如果w 已经被访问过
                w = GetNextNeighbor(i, w);
            }
        }

        public void DFS()
        {
            // 遍历所有的节点，进行 DFS
            for (int i = 0; i < GetNumOfVertex(); i++)
            {
                if (!isVisited[i])
                {
                    DFS(isVisited, i);
                }
            }
        }

        #endregion



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
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(edges[i, j]);
                }
                Console.WriteLine();
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
        public void InsertEdge(int v1, int v2, int weight)
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
            graph.InsertEdge(0, 1, 1);// A-B
            graph.InsertEdge(0, 2, 1);//A-C
            graph.InsertEdge(1, 2, 1);//B-C 
            graph.InsertEdge(1, 3, 1);// B-D
            graph.InsertEdge(1, 4, 1);//B-E

            graph.Show();

            Console.WriteLine("深度遍历：");
            graph.DFS();
        }
    }
}
