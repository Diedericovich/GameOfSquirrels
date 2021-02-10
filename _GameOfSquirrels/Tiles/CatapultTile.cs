using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace _GameOfSquirrels
{
    internal class CatapultTile : Tile
    {
        public CatapultTile(int locationX, int locationY)
            : base(locationX, locationY)
        {
            TileBorder = new Border();
            TileBorder.Background = Brushes.SaddleBrown;
        }

        public override void InteractWith(Pawn pawn)
        {
            pawn.Move(-1);
        }
    }
}