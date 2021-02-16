namespace _GameOfSquirrels
{
    public class TunnelTile : Tile
    {
        public TunnelTile(int locationX, int locationY)
            : base(locationX, locationY)
        {
            Image = "https://i.ibb.co/8bxVnVD/tunneltile.png";
        }

        public override string GetInteractionMessage()
        {
            return "You find a secret tunnel!";
        }
    }
}