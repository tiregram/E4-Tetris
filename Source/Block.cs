using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class Block : Grid
    {
        int x, y;
        char c;

        private Board myBoard; 
        public Board MyBoard
        {
            set
            {
                myBoard = value;
                if(myBoard!=null)
                {
                    this.x = myBoard.columns / 2;
                }
            }
            get
            {
                return myBoard; 
            }
        } 

        public Block(char _c, Board _b)
        {
            c = _c;
            MyBoard = _b;
            y = 0; 
        }

        public Block(char _c):this(_c, null)
        {
        }


        public bool Tick()
        {
            

            if(MyBoard.rows - 1>this.y)
            { // peux descendre dans la board
                if (MyBoard.boardValues[x, y + 1] != '.')
                { // pas de block en desous
                    return false;
                }
                //descend
                this.y++;
                return true; 
            }
            else
            { //fin
                return false; 
            }
        }

        public override String ToString()
        {
            return "" + this.c; 
        }

        public String ToString(int _x,int _y,char cc)
        {
            if (this.x==_x && this.y==_y ) {
                return "" + this.c;
            }
            return ""+cc;
        }
        
        public void printInBoard()
        {
            MyBoard.boardValues[this.x, this.y] = this.c; 
        }

        public int Rows()
        {
            return 1; 
        }

        public int Columns()
        {
            return 1; 
        }

        public char CellAt(int row, int col)
        {
            return c; 
        }
    }
}
