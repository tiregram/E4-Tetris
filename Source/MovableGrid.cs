using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class MovableGrid : Grid
    {
        public int x, y;
        char c;
        public Tetromino t;
        public int valState; 

        private Board myBoard; 
        public Board MyBoard
        {
            set
            {
                myBoard = value;
                if(myBoard!=null)
                {
                    this.x = myBoard.columns/2 - ((Grid)this).Columns()/2 ;
                    this.y = - ((Grid)this).Rows() / 2;
                    if(!this.check())
                    {
                        y++;
                    }
                }
            }
            get
            {
                return myBoard; 
            }
        } 

        public MovableGrid(char _c, Board _b)
        {
            c = _c;
            MyBoard = _b;
            y = 0; 
        }

        public MovableGrid():this('U',null)
        {
        }

        public MovableGrid(Tetromino pt) : this('U', null)
        {
            this.t = pt;
        }

        public MovableGrid RotateRight()
        {
            MovableGrid ret = new MovableGrid(this);

            ret.valState = (ret.valState + 1) % t.state.GetLength(0);

            return ret;
        }

        public MovableGrid RotateLeft()
        {
            MovableGrid ret = new MovableGrid(this);

            ret.valState = (t.state.GetLength(0) + ret.valState - 1) % t.state.GetLength(0);

            return ret;
        }


        public MovableGrid(MovableGrid g)
        {
            this.x = g.x;
            this.y = g.y;
            this.t = new Tetromino(g.t);
            this.t.mg = this;
            this.myBoard = g.myBoard;
            this.valState = g.valState;
            this.c = g.c;
        }


        public bool check()
        {
            for (int row = 0; row < ((Grid)this).Rows(); row++)
            {
                for (int col = 0; col < ((Grid)this).Columns(); col++)
                {
                    if (((Grid)this).CellAt(row, col) =='.' || ((Grid)this.myBoard).CellAt(this.y + row, this.x + col) == '.')
                    {

                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true; 
        }

        public bool Tick()
        {
            this.y++;

            if(this.check())
            {
                return true; 
            } 
            else
            {
                y--;
                return false; 
            }
        }

        public override String ToString()
        {
            return "" + this.c; 
        }

        public String ToString(int _row,int _col,char cc)
        {
            if (_col-this.x >= 0 
                && _col-this.x < ((Grid)this).Columns()
                && _row-this.y >= 0 
                && _row - this.y < ((Grid)this).Rows() )
            {
                if(((Grid)this).CellAt(_row - this.y, _col - this.x) == '.')
                {
                    return "" + cc;
                }
                return "" + ((Grid)this).CellAt(_row-this.y, _col-this.x );
            }
            return ""+cc;
        }

        public MovableGrid MoveLeft()
        {
            MovableGrid ret = new MovableGrid(this);
            ret.x--; 
            return ret; 
        }

        internal MovableGrid MoveRight()
        {
            MovableGrid ret = new MovableGrid(this);
            ret.x++;
            return ret;
        }

        public void printInBoard()
        {
            for (int row = 0; row < ((Grid)this).Rows() ; row++)
            {
                for (int col = 0; col < ((Grid)this).Columns(); col++)
                {
                    if(this.x + col >= 0 && this.x + col< ((Grid)myBoard).Columns() && 
                        this.y + row >= 0 && this.y + row < ((Grid)myBoard).Rows())
                    {
                        if(((Grid)this).CellAt(row, col) != '.')
                        {
                            MyBoard.boardValues.blocks[this.y + row, this.x + col] = ((Grid)this).CellAt(row, col);
                        }

                    }
                }
            }
        }

         int Grid.Rows()
        {
            return t.Rows(); 
        }

         int Grid.Columns()
        {
            return t.Columns(); 
        }

         char Grid.CellAt(int row, int col)
        {
            return t.CellAt(row,col); 
        }
    }
}
