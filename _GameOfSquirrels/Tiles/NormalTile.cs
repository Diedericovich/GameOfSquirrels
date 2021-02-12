using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace _GameOfSquirrels.Tiles
{
    internal class NormalTile : ITile
    {
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public Border TileBorder { get; set; }

        public int GetInteraction()
        {
            return 0;
        }
    }
}