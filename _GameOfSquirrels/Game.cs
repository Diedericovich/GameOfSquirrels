using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            Playerlist = pawnFactory.CreatePawns(1);
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
            if (Playerlist[CurrentPlayer].IsReversed)
            {
                Playerlist[CurrentPlayer].GoingRight = false;
                Playerlist[CurrentPlayer].IsReversed = false;
            }
            Dice dice = new Dice();
            int roll = dice.RollDice(1, 7);
            LastNumberRolled = roll;
            MovePawn(roll);
            NextTurn();
        }

        public async void MovePawn(int roll)
        {
            for (int i = 1; i < roll + 1; i++)
            {
                if (i == roll)
                {
                    PlayerFinishedMoving = true;
                }

                MoveOnBoard();

                if (PlayerFinishedMoving)
                {
                    CheckForSpecialTile();
                }
                await Task.Delay(300);
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

        private void CheckForSpecialTile()
        {
            foreach (ITile tile in BoardTiles)
            {
                if (Playerlist[CurrentPlayer].LocationX == tile.LocationX && Playerlist[CurrentPlayer].LocationY == tile.LocationY)
                {
                    if (tile is BridgeTile)
                    {
                        InteractWithBridge(tile);
                    }
                    if (tile is FireTile)
                    {
                        InteractWithFire(tile);
                    }
                    if (tile is SquirrelTile)
                    {
                        InteractWithSquirrel(tile);
                    }
                    if (tile is CatapultTile)
                    {
                        InteractWithCatapult(tile);
                    }
                    if (tile is EndGameTile)
                    {
                        InteractWithEndGame(tile);
                    }
                }
            }
        }

        private void InteractWithEndGame(ITile tile)
        {
            tile.GetInteraction();
            EndGame();
        }

        private void InteractWithCatapult(ITile tile)
        {
            tile.GetInteraction();
            PlayerFinishedMoving = false;
            MovePawn(3);
        }

        private void InteractWithSquirrel(ITile tile)
        {
            PlayerFinishedMoving = false;
            tile.GetInteraction();
            MovePawn(LastNumberRolled);
        }

        private void InteractWithFire(ITile tile)
        {
            Playerlist[CurrentPlayer].GoingRight = true;
            tile.GetInteraction();
            Playerlist[CurrentPlayer].LocationX = 0;
            Playerlist[CurrentPlayer].LocationY = 0;
            Playerlist[CurrentPlayer].Move(0, 0);
        }

        private void InteractWithBridge(ITile tile)
        {
            PlayerFinishedMoving = false;
            tile.GetInteraction();
            MovePawn(2);
        }

        private void MoveOnBoard()
        {
            if (Playerlist[CurrentPlayer].LocationX == BoardWidth - 1 && Playerlist[CurrentPlayer].GoingRight)
            {
                Playerlist[CurrentPlayer].Move(0, 1);
                Playerlist[CurrentPlayer].GoingRight = false;
            }
            else if (Playerlist[CurrentPlayer].LocationX == 0 && Playerlist[CurrentPlayer].LocationY == BoardHeight - 1)
            {
                Playerlist[CurrentPlayer].Move(1, 0);
                Playerlist[CurrentPlayer].GoingRight = true;
                Playerlist[CurrentPlayer].IsReversed = true;
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
        }

        private void EndGame()
        {
        }
    }
}