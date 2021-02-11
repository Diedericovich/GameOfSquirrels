using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _GameOfSquirrels
{
    internal class BridgeTile : Tile
    {
        public BridgeTile(int locationX, int locationY)
            : base(locationX, locationY)
        {
            TileBorder = new Border();
            TileBorder.Background = Brushes.Black;
        }

        public override int GetInteraction()
        {
            MessageBox.Show("Going over a bridge! You move two spaces forward!");
            return 2;
        }
    }
}