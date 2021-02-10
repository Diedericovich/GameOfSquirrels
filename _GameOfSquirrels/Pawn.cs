using System;
using System.Collections.Generic;
using System.Text;

namespace _GameOfSquirrels
{
    class Pawn : IPawn
    {
        private int _locationX;

        public int LocationX
        {
            get { return _locationX; }
            set { _locationX = value; }
        }

        private int _locationY;

        public int LocationY
        {
            get { return _locationY; }
            set { _locationY = value; }
        }


    }
}
