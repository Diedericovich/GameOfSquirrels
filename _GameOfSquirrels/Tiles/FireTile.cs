using System;
using System.Collections.Generic;
using System.Text;

namespace _GameOfSquirrels
{
    internal class FireTile : Tile
    {
        public FireTile(int locationX, int locationY)
            : base(locationX, locationY)
        {
        }

        public override void InteractWith(IPawn pawn)
        {
        }
    }
}