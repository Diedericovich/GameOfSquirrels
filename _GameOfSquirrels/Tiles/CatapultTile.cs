using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using _GameOfSquirrels.Tiles;

namespace _GameOfSquirrels
{
    public class CatapultTile : Tile
    {
        public CatapultTile(int locationX, int locationY)
            : base(locationX, locationY)
        {
            TileBorder = new Border();
            TileBorder.Background = Brushes.SaddleBrown;
        }

        public override void InteractWith(IPawn pawn)
        {
            pawn.Move(-3);
            MessageBox.Show("You got thrown back");
        }
    }
}