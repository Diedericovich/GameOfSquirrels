using System.Windows;

namespace _GameOfSquirrels
{
    public class TeleportTile : Tile
    {
        public TeleportTile(int locationX, int locationY)
            : base(locationX, locationY)
        {
            Image = "https://i.ibb.co/LtSPvyr/teleporttile.png";
        }

        public override string GetInteractionMessage()
        {
            return "Random teleport!";
        }
    }
}