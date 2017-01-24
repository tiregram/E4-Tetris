using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class Piece : Grid
    {
        StringToMatrix converter; 

        int Grid.Rows()
        {
            return converter.blocks.GetLength(0); 
        }
        int Grid.Columns()
        {
            return converter.blocks.GetLength(1); 
        }
        char Grid.CellAt(int row, int col)
        {
            return converter.blocks[row, col];
        }

        public Piece(string s)
        {
            converter = new StringToMatrix(s); 
        }

        public override string ToString()
        {
            return StringToMatrix.Inverse(converter.blocks, ((Grid)this).Rows(), ((Grid)this).Columns() );
        }

    }
}
