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
            if(grid=="")
            {
                return; 
            }
            blocks = stringToTab(grid); 
        }

        private char[,] stringToTab(string s)
        {

            int sizeCol = s.IndexOf('\n');
            int sizeRow = s.Length / (sizeCol + 1);

            char[,] tab = new char[sizeRow, sizeCol];

            for (int row = 0; row < sizeRow; row++)
            {
                for (int col = 0; col < sizeCol; col++)
                {
                    tab[row, col] = s[col + row * (sizeCol + 1)];
                }

            }

            return tab;
        }

        public static string Inverse(char[,] mat, int _row, int _col)
        {
            string str = "";
            for (int row = 0; row < mat.GetLength(0); row++)
            {
                for (int col = 0; col < mat.GetLength(1); col++)
                {
                    str += mat[row, col];
                }
                str += "\n";
            }

            return str;
        }

    }
}
