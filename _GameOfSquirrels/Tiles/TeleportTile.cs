using System.Windows;
using System.Windows.Controls;

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
            MessageBox.Show("Random teleport!");
            return 0;
        }
    }
}