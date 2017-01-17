using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class Board
    {
        readonly int rows;
        readonly int columns;

        public Board(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
        }

        public override String ToString()
        {
            String s = "";
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    s += "?";
                }
                s += "\n";
            }
            return s;
        }
    }
}
