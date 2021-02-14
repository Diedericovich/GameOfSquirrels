using System.Collections.Generic;

namespace _GameOfSquirrels
{
    internal class TileFactory
    {
        public List<ITile> CreateTiles(int boardHeight, int boardWidth)
        {
            List<ITile> tiles = new List<ITile>();
            //int counter = 0;

            //for (int i = 0; i < boardHeight; i++)
            //{

            //    for (int j = 0; j < boardWidth; j++)
            //    {
            //        tiles.Add(new NormalTile(i, j));
            //    }
            //}

            tiles.Add(new BridgeTile(1, 0));
            tiles.Add(new SquirrelTile(2, 0));
            tiles.Add(new CatapultTile(5, 0));
            tiles.Add(new SquirrelTile(6, 1));

            tiles.Add(new SquirrelTile(2, 2));
            tiles.Add(new SquirrelTile(5, 2));
            tiles.Add(new CatapultTile(6, 2));

            tiles.Add(new FireTile(0, 3));
            tiles.Add(new SquirrelTile(1, 3));
            tiles.Add(new SquirrelTile(4, 3));

            tiles.Add(new CatapultTile(2, 4));
            tiles.Add(new SquirrelTile(5, 4));

            tiles.Add(new SquirrelTile(1, 5));
            tiles.Add(new BridgeTile(6, 5));

            tiles.Add(new BridgeTile(4, 6));

            tiles.Add(new EndGameTile(0, 7));
            tiles.Add(new CatapultTile(2, 7));
            tiles.Add(new FireTile(5, 7));
            tiles.Add(new SquirrelTile(7, 7));

            return tiles;
        }
    }
}