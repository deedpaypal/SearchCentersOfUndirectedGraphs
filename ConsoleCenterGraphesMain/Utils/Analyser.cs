using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultidimensionalArrayFloydWarshall.Interfaces;

namespace MultidimensionalArrayFloydWarshall.Utils
{
    class Analyser:IAnalyser
    {
        public int[,] FloydWarshall(int[,] graph)
        {
            int[,] distance = (int[,]) graph.Clone();

            

            for (int k = 0; k < graph.GetLength(0); ++k)
            {
                for (int i = 0; i < graph.GetLength(0); ++i)
                {
                    for (int j = 0; j < graph.GetLength(0); ++j)
                    {
                        if (distance[i, k] + distance[k, j] < distance[i, j])
                        {
                            distance[i, j] = distance[i, k] + distance[k, j];
                        }

                    }
                }
            }
            return distance;
        }

        public int[] Excentricity(int[,] array)
        {
            int[] e = new int[array.GetLength(0)];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (i > j)
                    {
                        e[i] = Math.Max(e[i], array[j, i]);
                    }
                    else
                    {
                        e[i] = Math.Max(e[i], array[i, j]);
                    }
                }
            }
            return e;
        }

        public IList<int> GetCenters(int[] array)
        {
            IList<int> centerList = new List<int>();
            for (int i = 0; i < array.GetLength(0); ++i)
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
