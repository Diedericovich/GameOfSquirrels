using System.Windows;

namespace _GameOfSquirrels
{
    public class TunnelTile : Tile
    {
        public TunnelTile(int locationX, int locationY)
            : base(locationX, locationY)
        {
        }

        public override int GetInteraction()
        {
            MessageBox.Show("You find a secret tunnel!");
            return -3;
        }
    }
}