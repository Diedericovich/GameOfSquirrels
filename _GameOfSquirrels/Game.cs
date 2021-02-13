using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace _GameOfSquirrels
{
    public class Game
    {
        private Board board;
        public List<ITile> BoardTiles;
        public int BoardWidth;
        private Dice dice = new Dice();
        public List<IPawn> Playerlist;

        public Game(Grid gridGame)
        {
            GridGame = gridGame;
            CurrentPlayer = 0;
        }

        public int RoundCounter { get; set; }
        public int LastNumberRolled { get; set; }

        public Grid GridGame { get; set; }

        public int CurrentPlayer { get; set; }

        public void GenerateBoard()
        {
            BoardWidth = 40;
            board = new Board(GridGame, 4, BoardWidth);

            GenerateTiles();
            GeneratePawns();
        }

        private void GeneratePawns()
        {
            var pawnFactory = new PawnFactory();
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
            var tileFactory = new TileFactory();
            BoardTiles = tileFactory.CreateTiles();
            foreach (var tile in BoardTiles)
            {
                GridGame.Children.Add(tile.TileBorder);
                Grid.SetColumn(tile.TileBorder, tile.LocationX);
                Grid.SetRow(tile.TileBorder, tile.LocationY);
            }
        }

        public void MovePawn(int move)
        {
            Playerlist[CurrentPlayer].Move(move);
            foreach (var tile in BoardTiles)
                if (Playerlist[CurrentPlayer].LocationX == tile.LocationX)
                {
                    if (tile is SquirrelTile)
                    {
                        tile.GetInteraction();
                        MovePawn(LastNumberRolled);
                    }
                    else if (tile is FireTile)
                    {
                        tile.GetInteraction();
                        Grid.SetColumn(Playerlist[CurrentPlayer].Ellipse, 0);
                        Playerlist[CurrentPlayer].LocationX = 0;
                    }
                    else
                    {
                        MovePawn(tile.GetInteraction());
                    }
                }

            if (Playerlist[CurrentPlayer].LocationX >= BoardWidth - 1)
                MessageBox.Show($"Player{CurrentPlayer} Wins!");
            //Playerlist[CurrentPlayer].LocationX = 0;
            //Grid.SetColumn(Playerlist[CurrentPlayer].Ellipse, Playerlist[CurrentPlayer].LocationX);
        }

        private void NextTurn()
        {
            CurrentPlayer++;
            if (CurrentPlayer > Playerlist.Count - 1)
            {
                CurrentPlayer = 0;
                RoundCounter++;
            }
        }

        public void DoTurn()
        {
            var dice = new Dice();
            var roll = dice.RollDice(1, 7);
            LastNumberRolled = roll;
            MovePawn(roll);
            NextTurn();
        }
    }
}