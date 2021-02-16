using System.Windows;

namespace _GameOfSquirrels
{
    public class CatapultTile : Tile
    {
        public CatapultTile(int locationX, int locationY)
            : base(locationX, locationY)
        {
        }

        public override string GetInteractionMessage()
        {
            return "The catapult fires you 3 spaces forward!";
        }
    }
}