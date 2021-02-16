namespace _GameOfSquirrels
{
    public class SquirrelTile : Tile
    {
        public SquirrelTile(int locationX, int locationY)
                        : base(locationX, locationY)
        {
            Image = "https://i.ibb.co/j5zP1Br/squirreltile.png";
        }

        public override string GetInteractionMessage()
        {
            return "A friendly squirrel helps you move forward again!";
        }
    }
}