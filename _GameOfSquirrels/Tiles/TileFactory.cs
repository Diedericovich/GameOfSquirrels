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
            //    counter++;
            //    for (int j = 0; j < boardWidth; j++)
            //    {
            //        if (counter%2 ==0)
            //        {
            //            tiles.Add(new BridgeTile(i, j));
            //        }
            //        else
            //        {
            //            //tiles.Add(new NormalTile(i, j));
            //        }
            //    }

            //}

            tiles.Add(new BridgeTile(3, 0));
            //tiles.Add(new SquirrelTile(5, 0));
            //tiles.Add(new FireTile(6, 0));
            //tiles.Add(new CatapultTile(7, 0));
            //tiles.Add(new SquirrelTile(2, 1));
            //tiles.Add(new CatapultTile(3, 1));
            //tiles.Add(new BridgeTile(4, 1));
            //tiles.Add(new FireTile(5, 1));
            //tiles.Add(new BridgeTile(6, 1));
            //tiles.Add(new CatapultTile(7, 1));
            //tiles.Add(new FireTile(0, 2));
            //tiles.Add(new BridgeTile(1, 2));
            //tiles.Add(new BridgeTile(3, 2));
            //tiles.Add(new CatapultTile(5, 2));
            //tiles.Add(new FireTile(6, 2));
            //tiles.Add(new BridgeTile(4, 3));
            //tiles.Add(new BridgeTile(6, 3));
            //tiles.Add(new BridgeTile(3, 4));
            //tiles.Add(new BridgeTile(5, 4));
            //tiles.Add(new BridgeTile(4, 5));
            //tiles.Add(new BridgeTile(6, 5));
            //tiles.Add(new BridgeTile(1, 6));
            //tiles.Add(new BridgeTile(3, 6));
            tiles.Add(new EndGameTile(0, 7));
            //tiles.Add(new BridgeTile(1, 7));
            //tiles.Add(new BridgeTile(2, 7));
            //tiles.Add(new BridgeTile(3, 7));
            //tiles.Add(new BridgeTile(4, 7));
            //tiles.Add(new BridgeTile(5, 7));

            return tiles;
        }
    }
}