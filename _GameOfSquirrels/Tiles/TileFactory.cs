using System.Collections.Generic;
using _GameOfSquirrels.Tiles;

namespace _GameOfSquirrels
{
    internal class TileFactory
    {
        public List<ITile> CreateTiles(int boardHeight, int boardWidth)
        {
            List<ITile> tiles = new List<ITile>();
            int counter = 0;

            for (int i = 0; i < boardHeight; i++)
            {
                counter++;
                for (int j = 0; j < boardWidth; j++)
                {
                    if (counter%2 ==0)
                    {
                        tiles.Add(new BridgeTile(i, j));
                    }
                    else
                    {
                        tiles.Add(new NormalTile(i, j));
                    }
                }

            }

            return tiles;
        }
    }
}