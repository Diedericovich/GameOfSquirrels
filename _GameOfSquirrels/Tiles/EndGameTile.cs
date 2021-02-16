using System.Windows;
using System.Windows.Controls;

namespace _GameOfSquirrels
{
    internal class EndGameTile : Tile
    {
        public EndGameTile(int locationX, int locationY)
        : base(locationX, locationY)
        {
        }

        public override string GetInteractionMessage()
        {
            return "You win!";
        }
    }
}