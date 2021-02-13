using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _GameOfSquirrels
{
    internal class EndGameTile : Tile
    {
        public EndGameTile(int locationX, int locationY)
        : base(locationX, locationY)
        {
            TileBorder = new Border();
            TileBorder.Background = Brushes.LawnGreen;
        }

        public override int GetInteraction()
        {
            MessageBox.Show("You win!");
            return 0;
        }
    }
}