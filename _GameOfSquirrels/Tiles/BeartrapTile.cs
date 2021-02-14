using System.Windows;

namespace _GameOfSquirrels
{
    public class BeartrapTile : Tile
    {
        public BeartrapTile(int locationX, int locationY)
             : base(locationX, locationY)
        {
        }

        public override int GetInteraction()
        {
            MessageBox.Show("You're stuck!");
            return -3;
        }
    }
}