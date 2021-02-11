using System;
using System.Collections.Generic;
using System.Text;

namespace _GameOfSquirrels
{
    public class TeleportTile : Tile
    {
        public TeleportTile(int locationX, int locationY)
            : base(locationX, locationY)
        {

        }
        public override int GetInteraction()
        {
            return 0;
        }
    }
}
