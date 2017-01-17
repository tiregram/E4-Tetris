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

        void rotateRight()
        {
            this.valState = (this.valState + 1) % state.GetLength(0);
        }

        void rotateLefts()
        {
            this.valState = (this.valState - 1 + state.GetLength(0)) % state.GetLength(0);
        }


        char[,] getCurrentState()
        {
            return state[valState];
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

            char[,] tab = new char[sizeX, sizeY]; 

            for(int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    tab[x, y] = s[x + y * (sizeX+1)]; 
                }

            }

            return tab; 
        }
    }
}
