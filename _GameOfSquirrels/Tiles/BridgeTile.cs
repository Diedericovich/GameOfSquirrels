using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace _GameOfSquirrels
{
    internal class BridgeTile : Tile
    {
        public BridgeTile(int locationX, int locationY)
            : base(locationX, locationY)
        {
            TileBorder = new Border();
            TileBorder.Background = Brushes.LightSlateGray;
        }

        public override int GetInteraction()
        {
            MessageBox.Show("Going over a bridge! You move two spaces forward!");
            return 2;
        }
    }
}