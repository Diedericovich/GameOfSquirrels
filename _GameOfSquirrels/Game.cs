using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace _GameOfSquirrels
{
    public class Game
    {
        private Dice dice = new Dice();
        private Board board;
        public List<IPawn> Playerlist;
        public List<ITile> BoardTiles;
        public int BoardWidth;
        public int RoundCounter { get; set; }
        public int LastNumberRolled { get; set; }

        public Grid GridGame { get; set; }

        public int CurrentPlayer { get; set; }

        public Game(Grid gridGame)
        {
            GridGame = gridGame;
            CurrentPlayer = 0;
        }

        public void GenerateBoard()
        {
            BoardWidth = 20;
            board = new Board(GridGame, 2, BoardWidth);
            GridGame.ShowGridLines = true;
            GenerateTiles();
            GeneratePawns();
        }

        private void GeneratePawns()
        {
            PawnFactory pawnFactory = new PawnFactory();
            Playerlist = pawnFactory.CreatePawns(2);
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
            foreach (ITile tile in BoardTiles)
            {
                GridGame.Children.Add(tile.TileBorder);
                Grid.SetColumn(tile.TileBorder, tile.LocationX);
                Grid.SetRow(tile.TileBorder, tile.LocationY);
            }
        }

        public void MovePawn(int move)
        {
            Playerlist[CurrentPlayer].Move(move);
            foreach (ITile tile in BoardTiles)
            {
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
            }

            if (Playerlist[CurrentPlayer].LocationX >= BoardWidth-1)
            {
                MessageBox.Show($"Player{CurrentPlayer} Wins!");
                //Playerlist[CurrentPlayer].LocationX = 0;
                //Grid.SetColumn(Playerlist[CurrentPlayer].Ellipse, Playerlist[CurrentPlayer].LocationX);
            }
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
            Dice dice = new Dice();
            int roll = dice.RollDice(1, 7);
            LastNumberRolled = roll;
            MovePawn(roll);
            NextTurn();
        }
    }
}