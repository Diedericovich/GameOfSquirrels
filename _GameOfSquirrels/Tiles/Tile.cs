using System;
using System.Collections.Generic;
using System.Text;

namespace _GameOfSquirrels
{
    abstract class Tile : ITile
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

        public Tile(int locationX, int locationY)
        {
            LocationX = locationX;
            LocationY = locationY;
        }

        public virtual void InteractWith(Pawn pawn)
        {

        }
    }
}
