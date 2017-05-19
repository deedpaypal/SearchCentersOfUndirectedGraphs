using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayOfArraysFloydWarshall.Utils
{
    class MatrixPrinter
    {
       
        public static void Print(int[][] distance)
        {
            Console.WriteLine("Shortest distances between every pair of vertices:");

            for (int i = 0; i < distance.GetLength(0); ++i)
            {
                for (int j = 0; j < distance.GetLength(0); ++j)
                {
                    if (distance[i][j] == Int32.MaxValue)
                        Console.Write("INF".PadLeft(7));
                    else
                        Console.Write(distance[i][j].ToString().PadLeft(7));
                }

                Console.WriteLine();
            }
        }
    }
}
