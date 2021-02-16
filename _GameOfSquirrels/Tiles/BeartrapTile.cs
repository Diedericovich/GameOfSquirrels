using System.Windows;

namespace _GameOfSquirrels
{
    public class BearTrapTile : Tile
    {
        public BearTrapTile(int locationX, int locationY)
             : base(locationX, locationY)
        {
            Image = "https://i.ibb.co/BCV1z2b/beartrap.png";
        }

        public override string GetInteractionMessage()
        {
            return "You're stuck!";
        }
    }
}