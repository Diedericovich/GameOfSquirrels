using System.Windows;
using System.Windows.Controls;

namespace _GameOfSquirrels
{
    internal class FireTile : Tile
    {
        public FireTile(int locationX, int locationY)
            : base(locationX, locationY)
        {
        }

        public override string GetInteractionMessage()
        {
            return "Fire! Move back to the start!";
        }
    }
}