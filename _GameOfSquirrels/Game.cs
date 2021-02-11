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

        public int CurrentPlayer { get; set; }

        public Game(Grid gridGame)
        {
            GridGame = gridGame;
            CurrentPlayer = 0;
        }

        public void GenerateBoard()
        {
            board = new Board(GridGame, 0, 20);
            GridGame.ShowGridLines = true;
            GenerateTiles();
            GeneratePawns();
        }

        private void GeneratePawns()
        {
            PawnFactory pawnFactory = new PawnFactory();
            Playerlist = pawnFactory.CreatePawns(4);
            foreach (var item in Playerlist)
            {
                GridGame.Children.Add(item.Ellipse);
                Grid.SetColumn(item.Ellipse, item.LocationX);
                Grid.SetRow(item.Ellipse, item.LocationY);
            }
        }

        private void GenerateTiles()
        {
            TileFactory tileFactory = new TileFactory();
            BoardTiles = tileFactory.CreateTiles();
            foreach (var tile in BoardTiles)
            {
                GridGame.Children.Add(tile.TileBorder);
                Grid.SetColumn(tile.TileBorder, tile.LocationX);
            }
        }

        public void MovePawn(int move)
        {
            Playerlist[CurrentPlayer].Move(move);
            foreach (var item in BoardTiles)
            {
                if (Playerlist[CurrentPlayer].LocationX == item.LocationX)
                {
                    MovePawn(item.GetInteraction());
                }
            }

            if (Playerlist[CurrentPlayer].LocationX >= 20)
            {
                Playerlist[CurrentPlayer].LocationX = 0;
                Grid.SetColumn(Playerlist[CurrentPlayer].Ellipse, Playerlist[CurrentPlayer].LocationX);
            }
        }

        private void NextTurn()
        {
            CurrentPlayer++;
            if (CurrentPlayer > Playerlist.Count - 1)
            {
                CurrentPlayer = 0;
            }
        }

        public void DoTurn()
        {
            Dice dice = new Dice();
            MovePawn(dice.RollDice(1, 7));
            NextTurn();
        }
    }
}