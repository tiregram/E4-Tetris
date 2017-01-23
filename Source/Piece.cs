using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    class Piece : Grid
    {
        int Rows()
        int Columns();
        char CellAt(int row, int col);

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

    }
}
