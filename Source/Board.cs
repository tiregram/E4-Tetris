using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class Board : Grid
    {
        public readonly int rows;
        public readonly int columns;
        //public char[,] boardValues; 
        public StringToMatrix boardValues;

        MovableGrid currentBlock;

        int Grid.Rows()
        {
            return rows; 
        }

        int Grid.Columns()
        {
            return columns; 
        }

        char Grid.CellAt(int row, int col)
        {
            if(row >= 0 && col >= 0 && row < ((Grid)this).Rows() && col < ((Grid)this).Columns() )
            {
                return boardValues.blocks[row, col];
            }
            else
            {
                if (row < 0)
                    return '|';
                else
                    return '|';
            }
        }

        public void RotateRight()
        {
            if (this.currentBlock != null)
            {
                MovableGrid ret = TryRotate(this.currentBlock.RotateRight());
                if (ret != null)
                    this.currentBlock = ret;
                }
        }

        public void MoveDown()
        {
            this.Tick(); 
        }

        public Board(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            this.currentBlock = null;
            boardValues = new StringToMatrix(""); 
            boardValues.blocks = new char[rows, columns];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    boardValues.blocks[row, col] = '.';
                }
            }
        }

        public void RotateLeft()
        {

            if (this.currentBlock != null)
            {
                MovableGrid ret = TryRotate(this.currentBlock.RotateLeft());
                if (ret != null)
                    this.currentBlock = ret;
                }
        }

        public void MoveLeft()
        {
            if (this.currentBlock == null)
                return;
            this.currentBlock.x--; 
            if(!this.currentBlock.check())
            {
                this.currentBlock.x++; 
            }
        }

        MovableGrid TryRotate(MovableGrid rotated)
        {
            MovableGrid[] moves = {
                rotated ,
                rotated.MoveLeft(), // wallkick moves
                rotated.MoveRight(),
                rotated.MoveLeft().MoveLeft(),
                rotated.MoveRight().MoveRight(),
            };
            foreach (MovableGrid test in moves)
            {
                if (test.check())
                {
                    return test;
                }
            }
            return null; 
        }

        public void MoveRight()
        {
            if (this.currentBlock == null)
                return; 
            this.currentBlock.x++;
            if (!this.currentBlock.check())
            {
                this.currentBlock.x--;
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
                        s += this.currentBlock.ToString(row, col, boardValues.blocks[row,col]);
                    }
                    else
                    {
                        s += boardValues.blocks[row, col]; 
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

        public void Drop(MovableGrid _c)
        {
            if (!this.IsFallingBlock())
            {
                _c.MyBoard = this;
                this.currentBlock = _c;
            }
            else
                throw new ArgumentException("A block is already falling.");
        }

        public void FromString(string v)
        {
            this.boardValues = new StringToMatrix(v); 
        }

        public void Drop(Tetromino grid)
        {
            MovableGrid b = (MovableGrid) grid.mg;
            this.Drop(b); 
        }


        public void Tick()
        {
            if(this.IsFallingBlock() && !this.currentBlock.Tick())
            {
                this.currentBlock.printInBoard(); 
                this.currentBlock = null; 
            }

            checkLines();
        }

        private void checkLines()
        {
            List<int> toDelete = new List<int>();
            for (int row = 0; row < rows; row++)
            {
                bool isfull = true; 
                for (int col = 0; col < columns; col++)
                {
                    if(boardValues.blocks[row, col] == '.')
                    {
                        isfull = false;
                    }
                }
                if (isfull)
                    toDelete.Add(row); 
            }

            foreach(int row in toDelete)
            {
                this.deleteLine(row);
            }
        }

        private void deleteLine(int row)
        {
            for (int i = row; i > 0; i--)
            {
                for (int col = 0; col < columns; col++)
                {
                    boardValues.blocks[i, col] = boardValues.blocks[i - 1, col];
                }
            }

            for (int col = 0; col < columns; col++)
            {
                boardValues.blocks[0, col] = '.';
            }
        }
    }
}
