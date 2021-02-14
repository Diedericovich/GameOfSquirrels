using System.Windows;

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