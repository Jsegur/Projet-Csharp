using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCsharp
{
    internal class Maps
    {
        public static void maps(string[] args)
        {
            string legend = "S : Start\nX : Point of interest\nD : Door\nE : Exit\nA : Enemy\nB : Strong enemy\nC : Boss";
            string[] tempmap = File.ReadAllLines("../../../Map.txt");

            char[,] map = ExtractMap(tempmap);
            int mapLength = map.GetLength(0);
            int mapWidth = map.GetLength(1);

            Console.WriteLine($"\nMap length : {mapLength}\nMap width : {mapWidth}");
            Console.WriteLine($"\nMap legend :\n{legend}");
        }
        public static char[,] ExtractMap(string[] input)
        {
            string[] tempmap = input;
            char[,] result = new char[tempmap.Length, tempmap.Max(i => i.Length)];
            for (int i = 0; i < tempmap.Length; i++)
            {
                for (int j = 0; j < tempmap[i].Length; j++)
                {
                    if (tempmap[i].Length <= j)
                        break;

                    result[i, j] = tempmap[i][j];
                }
            }
            return result;
        }
    }
}
