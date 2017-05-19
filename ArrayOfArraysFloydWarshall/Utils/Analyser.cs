using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrayOfArraysFloydWarshall.Interfaces;

namespace ArrayOfArraysFloydWarshall.Utils
{
    class Analyser:IAnalyser
    {
        public int[][] FloydWarshall(int[][] graph)
        {
            int[][] distance = (int[][])graph.Clone();

            for (int i = 0; i < graph.Length; ++i)
                for (int j = 0; j < graph.Length; ++j)
                    distance[i][j] = graph[i][j];

            for (int k = 0; k < graph.Length; ++k)
            {
                for (int i = 0; i < graph.Length; ++i)
                {
                    for (int j = 0; j < graph.Length; ++j)
                    {
                        if (distance[i][k] + distance[k][j] < distance[i][j])
                        {
                            distance[i][j] = distance[i][k] + distance[k][j];
                        }

                    }
                }
            }
            return distance;

        }
        public int[] Excentricity(int[][] array)
        {
            int[] e = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (i > j)
                    {
                        e[i] = Math.Max(e[i], array[j][i]);
                    }
                    else
                    {
                        e[i] = Math.Max(e[i], array[i][j]);
                    }
                }
            }
            return e;
        }

        public IList<int> GetCenters(int[] array)
        {
            IList<int> centerList = new List<int>();
            for (int i = 0; i < array.Length; ++i)
            {
                if (array[i] == array.Min())
                {
                    centerList.Add(i + 1);

                }
            }
            return centerList;
        }
    }
}
