namespace _GameOfSquirrels
{
    public class SquirrelTile : Tile
    {
        public SquirrelTile(int locationX, int locationY)
                        : base(locationX, locationY)
        {
            Image = "https://i.ibb.co/DKVw6J8/smolacorn.png";
        }

        public override string GetInteractionMessage()
        {
            return "A friendly squirrel helps you move forward again!";
        }
    }
}