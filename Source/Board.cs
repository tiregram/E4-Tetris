using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class Board
    {
        public readonly int rows;
        public readonly int columns;
        public char[,] boardValues; 

        Block currentBlock;


        public Board(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            this.currentBlock = null;
            boardValues = new char[columns, rows];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    boardValues[col, row] = '.';
                }
            }
        }

        public override String ToString()
        {
            String s = "";
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if(IsFallingBlock())
                    {
                        s += this.currentBlock.ToString(col, row, boardValues[col,row]);
                    }
                    else
                    {
                        s += boardValues[col, row]; 
                    }
                }
                s += "\n";
            }
            return s;
        }

        public bool IsFallingBlock()
        {
            return this.currentBlock!=null;
        }

        public void Drop(Block _c)
        {
            if (!this.IsFallingBlock())
            {
                _c.MyBoard = this;
                this.currentBlock = _c;
            }
            else
                throw new ArgumentException("A block is already falling.");
        }

        public void Tick()
        {
            
            if(this.IsFallingBlock() && !this.currentBlock.Tick())
            {
                this.currentBlock.printInBoard(); 
                this.currentBlock = null; 
            }
        }
    }
}
