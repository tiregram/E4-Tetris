using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class StringToMatrix
    {
        public char[,] blocks; 

        public StringToMatrix(string grid)
        {
            blocks = stringToTab(grid); 

        }

        private char[,] stringToTab(string s)
        {

            int sizeX = s.IndexOf('\n');
            int sizeY = s.Length / (sizeX + 1);

            char[,] tab = new char[sizeY, sizeX];

            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    tab[y, x] = s[x + y * (sizeX + 1)];
                }

            }

            return tab;
        }

        public static string Inverse(char[,] mat, int x, int y)
        {
            string str = "";
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    str += mat[i, j];
                }
                str += "\n";
            }

            return str;
        }

    }
}
