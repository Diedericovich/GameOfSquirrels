using System.Collections.Generic;

namespace _GameOfSquirrels
{
    internal class TileFactory
    {
        public List<ITile> CreateTiles(int boardHeight, int boardWidth)
        {
            List<ITile> tiles = new List<ITile>();

            //for (int i = 0; i < boardHeight; i++)
            //{
            //    for (int j = 0; j < boardWidth; j++)
            //    {
            //        tiles.Add(new BridgeTile(j, i));
            //    }

            //}


            tiles.Add(new BridgeTile(5, 2));
            tiles.Add(new BridgeTile(15, 4));
            tiles.Add(new BridgeTile(3, 0));
            tiles.Add(new BridgeTile(12, 2));
            tiles.Add(new BridgeTile(8, 3));


            //int counter = 2;
            //int counter1 = 0;
            //for (int i = 0; i < 4; i++)
            //{
            //    counter += 3;
            //    tiles.Add(new CatapultTile(counter, 0));
            //}
            //for (int i = 0; i < 2; i++)
            //{
            //    counter1 += 2;
            //    tiles.Add(new BridgeTile(counter1, 0));
            //}


            return tiles;
        }
    }
}