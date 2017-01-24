using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class Tetromino : Grid
    {
        Piece[] state;
        int valState;
        public MovableGrid mg;

        public static Tetromino T_SHAPE = new Tetromino(
                "....\n" +
                "TTT.\n" +
                ".T..\n"
            ,
                ".T..\n" +
                "TT..\n" +
                ".T..\n"
            ,
                "....\n" +
                ".T..\n" +
                "TTT.\n"
            ,
                ".T..\n" +
                ".TT.\n" +
                ".T..\n"
        );

        public static Tetromino I_SHAPE = new Tetromino(
                "....\n" +
                "IIII\n" +
                "....\n" +
                "....\n"
            ,
                "..I.\n" +
                "..I.\n" +
                "..I.\n" +
                "..I.\n"
        );

        public Tetromino RotateRight()
        {
            Tetromino ret = new Tetromino(this); 
            
            ret.valState = (ret.valState + 1) % state.GetLength(0);

            return ret; 
        }

        public Tetromino RotateLeft()
        {
            Tetromino ret = new Tetromino(this);

            ret.valState = (state.GetLength(0) + ret.valState - 1) % state.GetLength(0);

            return ret;
        }
         

        Piece getCurrentState()
        {
            return this.state[this.valState];
        }

        private Tetromino(int size,int rot = 0)
        {
            this.mg = new MovableGrid(this);
            state = new Piece[size];
            valState = rot;
            
        }

        public Tetromino (string a, string b, string c, string d):this(4)
        {
            state[0] = new Piece(a);
            state[1] = new Piece(b);
            state[2] = new Piece(c);
            state[3] = new Piece(d);
        }

        public Tetromino(string a, string b) : this(2)
        {
            state[0] = new Piece(a);
            state[1] = new Piece(b);
        }

        public Tetromino(string a) : this(1)
        {
            state[0] = new Piece(a);
        }


        private Tetromino(Tetromino a)
        {
            this.mg = new MovableGrid(this);
            this.state = a.state;
            this.valState = a.valState;
        }



        //private char[,] stringToTab (string s)
        //{

        //    int sizeX = s.IndexOf('\n');
        //    int sizeY = s.Length / (sizeX+1);

        //    char[,] tab = new char[sizeY, sizeX]; 

        //    for(int x = 0; x < sizeX; x++)
        //    {
        //        for (int y = 0; y < sizeY; y++)
        //        {
        //            tab[y, x] = s[x + y * (sizeX+1)]; 
        //        }

        //    }

        //    return tab; 
        //}

        //public override string ToString()
        //{
        //    string str = "";
        //    char[,] curentState = this.getCurrentState();
        //    for (int i = 0; i < curentState.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < curentState.GetLength(1); j++)
        //        {
        //            str += curentState[i, j];
        //        }
        //        str +="\n";
        //    }

        //    return str;
        //}

        public override string ToString()
        {
            return this.getCurrentState().ToString();
        }

        public virtual int Rows()
        {
            return ((Grid)this.getCurrentState()).Rows(); 
        }

        public virtual int Columns()
        {
            return ((Grid)this.getCurrentState()).Columns(); 
        }

        public virtual char CellAt(int row, int col)
        {
            return ((Grid)this.getCurrentState()).CellAt(row, col); 
        }
    }
}
