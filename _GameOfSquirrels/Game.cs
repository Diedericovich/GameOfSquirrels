using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace _GameOfSquirrels
{
    public class Game
    {
        private Dice dice = new Dice();
        private Board board;
        public List<IPawn> Playerlist;
        public List<ITile> BoardTiles;
        public int BoardWidth;
        public int BoardHeight;
        public bool PlayerFinishedMoving;
        public int RoundCounter { get; set; }
        public int LastNumberRolled { get; set; }

        public Grid GridGame { get; set; }

        public int CurrentPlayer { get; set; }

        public Game(Grid gridGame)
        {
            BoardWidth = 8;
            BoardHeight = 8;
            GridGame = gridGame;
            CurrentPlayer = 0;
        }

        public void GenerateBoard()
        {
            board = new Board(GridGame, BoardHeight, BoardWidth);
            BitmapImage img = new BitmapImage(new Uri(@"https://cdn.discordapp.com/attachments/809042663969652756/809745831732314152/TileGrass.png"));
            ImageBrush image = new ImageBrush();
            image.ImageSource = img;
            GridGame.Background = image;
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
            BoardTiles = tileFactory.CreateTiles(BoardHeight, BoardWidth);
            foreach (ITile tile in BoardTiles)
            {
                GridGame.Children.Add(tile.TileBorder);
                Grid.SetColumn(tile.TileBorder, tile.LocationX);
                Grid.SetRow(tile.TileBorder, tile.LocationY);
            }
        }

        public void DoTurn()
        {
            PlayerFinishedMoving = false;
            Dice dice = new Dice();
            int roll = dice.RollDice(1, 7);
            LastNumberRolled = roll;
            MovePawn(roll);
            NextTurn();
        }

        public void MovePawn(int roll)
        {
            for (int i = 1; i < roll + 1; i++)
            {
                if (i == roll)
                {
                    PlayerFinishedMoving = true;
                }

                if (Playerlist[CurrentPlayer].LocationX == BoardWidth - 1 && Playerlist[CurrentPlayer].GoingRight)
                {
                    Playerlist[CurrentPlayer].Move(0, 1);
                    Playerlist[CurrentPlayer].GoingRight = false;
                }
                else if (Playerlist[CurrentPlayer].LocationX == 0 && !Playerlist[CurrentPlayer].GoingRight)
                {
                    Playerlist[CurrentPlayer].Move(0, 1);
                    Playerlist[CurrentPlayer].GoingRight = true;
                }
                else if (Playerlist[CurrentPlayer].GoingRight)
                {
                    Playerlist[CurrentPlayer].Move(1, 0);
                }
                else
                {
                    Playerlist[CurrentPlayer].Move(-1, 0);
                }

                if (PlayerFinishedMoving)
                {
                    foreach (ITile tile in BoardTiles)
                    {
                        if (Playerlist[CurrentPlayer].LocationX == tile.LocationX && Playerlist[CurrentPlayer].LocationY == tile.LocationY)
                        {
                            if (tile is BridgeTile)
                            {
                                PlayerFinishedMoving = false;
                                tile.GetInteraction();
                                MovePawn(2);
                            }
                            if (tile is FireTile)
                            {
                                Playerlist[CurrentPlayer].GoingRight = true;
                                tile.GetInteraction();
                                Playerlist[CurrentPlayer].LocationX = 0;
                                Playerlist[CurrentPlayer].LocationY = 0;
                                Playerlist[CurrentPlayer].Move(0, 0);
                            }
                            if (tile is SquirrelTile)
                            {
                                PlayerFinishedMoving = false;
                                tile.GetInteraction();
                                MovePawn(LastNumberRolled);
                            }
                            if (tile is CatapultTile)
                            {
                                tile.GetInteraction();
                                PlayerFinishedMoving = false;
                                MovePawn(3);
                            }
                        }
                    }
                }
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
    }
}