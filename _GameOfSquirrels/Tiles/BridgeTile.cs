using System;
using System.Collections.Generic;
using System.Text;

namespace _GameOfSquirrels
{
    internal class BridgeTile : Tile
    {
        public BridgeTile(int locationX, int locationY)
            : base(locationX, locationY)
        {
        }

        public override void InteractWith(IPawn pawn)
        {
        }
    }
}