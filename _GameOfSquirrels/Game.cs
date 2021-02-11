using System.Collections.Generic;
using System.Windows.Controls;

namespace _GameOfSquirrels
{
   public class Game
    {
        private Dice dice = new Dice();
        private Board board;
        public List<IPawn> Playerlist;
        public List<ITile> BoardTiles;

        public Grid GridGame { get; set; }

        public Game(Grid gridGame)
        {
            GridGame = gridGame;
        }

        public void GamePlay()
        {
            board = new Board(GridGame, 0, 20);
            GridGame.ShowGridLines = true;
            TileFactory tileFactory = new TileFactory();
            BoardTiles = tileFactory.CreateTiles();
            foreach (var tile in BoardTiles)
            {
                GridGame.Children.Add(tile.TileBorder);
                Grid.SetColumn(tile.TileBorder, tile.LocationX);
            }

            Pawn pawn1 = new Pawn(3, 1);
            Pawn pawn2 = new Pawn(1, 1);
            Playerlist = new List<IPawn> { pawn1, pawn2 };
            foreach (var item in Playerlist)
            {
                GridGame.Children.Add(item.Ellipse);
                Grid.SetColumn(item.Ellipse, item.LocationX);
                Grid.SetRow(item.Ellipse, item.LocationY);
            }

        }

        public void MovePawn(int move)
        {
            Playerlist[0].Move(move);
            foreach (var item in BoardTiles)
            {
                if (Playerlist[0].LocationX == item.LocationX)
                {
                    MovePawn(item.GetInteraction());
                }
            }

            if (Playerlist[0].LocationX >= 20)
            {
                Playerlist[0].LocationX = 0;
                Grid.SetColumn(Playerlist[0].Ellipse, Playerlist[0].LocationX);
            }
        }
    }
}