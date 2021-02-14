using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace _GameOfSquirrels
{
    public class Game : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Dice dice = new Dice();
        private Board board;
        public List<IPawn> Playerlist;
        public List<ITile> BoardTiles;
        public int BoardWidth;
        public int BoardHeight;
        public bool PlayerFinishedMoving;
        private int _roundCounter;

        public int RoundCounter
        {
            get { return _roundCounter; }
            set { _roundCounter = value; OnPropertyChanged("RoundCounter"); }
        }

        private int _lastNumberRolled;

        public int LastNumberRolled
        {
            get { return _lastNumberRolled; }
            set
            {
                _lastNumberRolled = value;
                OnPropertyChanged("LastNumberRolled");
            }
        }

        public Grid GridGame { get; set; }

        private int _currentPlayer;

        public int CurrentPlayer
        {
            get { return _currentPlayer; }
            set { _currentPlayer = value; OnPropertyChanged("CurrentPlayer"); }
        }

        public Game(Grid gridGame)
        {
            BoardWidth = 8;
            BoardHeight = 8;
            GridGame = gridGame;
            GridGame.ShowGridLines = true;
            CurrentPlayer = 0;
        }

        public void GenerateBoard()
        {
            board = new Board(GridGame, BoardHeight, BoardWidth);
            BitmapImage img = new BitmapImage(new Uri(@"https://cdn.discordapp.com/attachments/809042663969652756/810496380548284476/Backgroundtest_-_demo1.png"));
            ImageBrush image = new ImageBrush();
            image.ImageSource = img;
            GridGame.Background = image;
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
            BoardTiles = tileFactory.CreateTiles(BoardHeight, BoardWidth);
            foreach (ITile tile in BoardTiles)
            {
                GridGame.Children.Add(tile.TileBorder);
                Grid.SetColumn(tile.TileBorder, tile.LocationX);
                Grid.SetRow(tile.TileBorder, tile.LocationY);
            }
        }

        //public void UpdatePawnLocation()
        //{
        //    foreach (var item in Playerlist)
        //    {
        //        Grid.SetColumn(item.Ellipse, item.LocationX);
        //        Grid.SetRow(item.Ellipse, item.LocationY);
        //    }
        //}

        public void DoTurn()
        {
            Playerlist[CurrentPlayer].IsReversed = false;
            CheckPlayerDirection();
            PlayerFinishedMoving = false;

            if (!Playerlist[CurrentPlayer].IsSkippingNextTurn)
            {
                Dice dice = new Dice();
                int roll = dice.RollDice(1, 7);
                int roll2 = dice.RollDice(1, 7);
                LastNumberRolled = roll + roll2;
                MovePawn(LastNumberRolled);
            }
            else
            {
                MessageBox.Show("Turn skipped");
                Playerlist[CurrentPlayer].TurnsToSkip -= 1;
                if (Playerlist[CurrentPlayer].TurnsToSkip == 0)
                {
                    Playerlist[CurrentPlayer].IsSkippingNextTurn = false;
                }
                PlayerFinishedMoving = true;
            }

            NextTurn();
        }

        private async void MovePawn(int roll)
        {
            for (int i = 1; i < roll + 1; i++)
            {
                await Task.Delay(300);
                if (i == roll)
                {
                    PlayerFinishedMoving = true;
                }

                MoveOnBoard();
            }
            if (PlayerFinishedMoving)
            {
                CheckForSpecialTile();
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
                    tile.GetInteraction();
                    switch (tile)
                    {
                        case BridgeTile:
                            InteractWithBridge();
                            break;

                        case FireTile:
                            InteractWithFire();
                            break;

                        case SquirrelTile:
                            InteractWithSquirrel();
                            break;

                        case CatapultTile:
                            InteractWithCatapult();
                            break;

                        case EndGameTile:
                            InteractWithEndGame();
                            break;

                        case TeleportTile:
                            InteractWithTeleport();
                            break;

                        case BeartrapTile:
                            InteractWithBeartrap();
                            break;

                        case TunnelTile:
                            InteractWithTunnel();
                            break;
                    }
                }
            }
        }

        private void InteractWithTunnel()
        {
            Playerlist[CurrentPlayer].GoingRight = true;
            Playerlist[CurrentPlayer].LocationX = 2;
            Playerlist[CurrentPlayer].LocationY = 6;
            Playerlist[CurrentPlayer].Move(0, 0);
        }

        private void InteractWithBeartrap()
        {
            Playerlist[CurrentPlayer].TurnsToSkip = 3;
            Playerlist[CurrentPlayer].IsSkippingNextTurn = true;
        }

        private void InteractWithTeleport()
        {
            Playerlist[CurrentPlayer].Move(dice.RollDice(0, 8), dice.RollDice(0, 8));
            CheckPlayerDirection();
        }

        private void InteractWithEndGame()
        {
            EndGame();
        }

        private void InteractWithCatapult()
        {
            PlayerFinishedMoving = false;
            MovePawn(3);
        }

        private void InteractWithSquirrel()
        {
            PlayerFinishedMoving = false;
            MovePawn(LastNumberRolled);
        }

        private void InteractWithFire()
        {
            Playerlist[CurrentPlayer].GoingRight = true;
            Playerlist[CurrentPlayer].LocationX = 0;
            Playerlist[CurrentPlayer].LocationY = 0;
            Playerlist[CurrentPlayer].Move(0, 0);
        }

        private void InteractWithBridge()
        {
            Playerlist[CurrentPlayer].Move(1, 1);
            if (Playerlist[CurrentPlayer].GoingRight)
            {
                Playerlist[CurrentPlayer].GoingRight = false;
            }
            else
            {
                Playerlist[CurrentPlayer].GoingRight = true;
            }
        }

        private void MoveOnBoard()
        {
            if (Playerlist[CurrentPlayer].LocationX == BoardWidth - 1 && Playerlist[CurrentPlayer].IsReversed && Playerlist[CurrentPlayer].GoingRight) // Right turn reverse
            {
                Playerlist[CurrentPlayer].Move(0, -1);
                Playerlist[CurrentPlayer].GoingRight = false;
            }
            else if (Playerlist[CurrentPlayer].LocationX == 0 && Playerlist[CurrentPlayer].IsReversed && !Playerlist[CurrentPlayer].GoingRight) // Left turn reverse
            {
                Playerlist[CurrentPlayer].Move(0, -1);
                Playerlist[CurrentPlayer].GoingRight = true;
            }
            else if (Playerlist[CurrentPlayer].LocationX == BoardWidth - 1 && Playerlist[CurrentPlayer].GoingRight) // Right turn
            {
                Playerlist[CurrentPlayer].Move(0, 1);
                Playerlist[CurrentPlayer].GoingRight = false;
            }
            else if (Playerlist[CurrentPlayer].LocationX == 0 && Playerlist[CurrentPlayer].LocationY == 0) //If at startµ
            {
                Playerlist[CurrentPlayer].GoingRight = true;
                Playerlist[CurrentPlayer].Move(1, 0);
            }
            else if (Playerlist[CurrentPlayer].LocationX == 0 && Playerlist[CurrentPlayer].LocationY == BoardHeight - 1)  //Go past the end
            {
                Playerlist[CurrentPlayer].Move(1, 0);
                Playerlist[CurrentPlayer].GoingRight = true;
                Playerlist[CurrentPlayer].IsReversed = true;
            }
            else if (Playerlist[CurrentPlayer].LocationX == 0 && !Playerlist[CurrentPlayer].GoingRight) // Left boardside turn
            {
                Playerlist[CurrentPlayer].Move(0, 1);
                Playerlist[CurrentPlayer].GoingRight = true;
            }
            else if (Playerlist[CurrentPlayer].GoingRight) // Move right
            {
                Playerlist[CurrentPlayer].Move(1, 0);
            }
            else // Move left
            {
                Playerlist[CurrentPlayer].Move(-1, 0);
            }
        }

        public void CheckPlayerDirection()
        {
            if (Playerlist[CurrentPlayer].LocationY % 2 == 0)
            {
                Playerlist[CurrentPlayer].GoingRight = true;
            }
            else
            {
                Playerlist[CurrentPlayer].GoingRight = false;
            }
        }

        private void EndGame()
        {
        }

        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}