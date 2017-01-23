using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class Tetromino
    {
        char[][,] state;
        int valState;

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
         

        char[,] getCurrentState()
        {
            return this.state[this.valState];
        }

        private Tetromino(int size,int rot = 0)
        {
            state = new char[size][,];
            valState = rot;
            
        }

        public Tetromino (string a, string b, string c, string d):this(4)
        {
            state[0] = this.stringToTab(a);
            state[1] = this.stringToTab(b);
            state[2] = this.stringToTab(c);
            state[3] = this.stringToTab(d);
        }

        public Tetromino(string a, string b) : this(2)
        {
            state[0] = this.stringToTab(a);
            state[1] = this.stringToTab(b);
        }

        public Tetromino(string a) : this(1)
        {
            state[0] = this.stringToTab(a);
        }


        private Tetromino(Tetromino a)
        {
            this.state = a.state;
            this.valState = a.valState;
        }



        private char[,] stringToTab (string s)
        {

            int sizeX = s.IndexOf('\n');
            int sizeY = s.Length / (sizeX+1);

            char[,] tab = new char[sizeY, sizeX]; 

            for(int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    tab[y, x] = s[x + y * (sizeX+1)]; 
                }

            }

            return tab; 
        }

        public override string ToString()
        {
            string str = "";
            char[,] curentState = this.getCurrentState();
            for (int i = 0; i < curentState.GetLength(0); i++)
            {
                for (int j = 0; j < curentState.GetLength(1); j++)
                {
                    str += curentState[i, j];
                }
                str +="\n";
            }

            return str;
        }
    }
}
