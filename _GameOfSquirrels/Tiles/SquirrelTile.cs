using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _GameOfSquirrels
{
    public class SquirrelTile : Tile
    {
        public SquirrelTile(int locationX, int locationY)
                        : base(locationX, locationY)
        {
            TileBorder = new Border();
            TileBorder.Background = Brushes.BlanchedAlmond;
        }

        public override int GetInteraction()
        {
            MessageBox.Show("A friendly squirrel helps you move forward again!");
            return 0;
        }
    }
}