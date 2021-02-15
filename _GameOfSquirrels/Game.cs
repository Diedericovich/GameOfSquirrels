using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _GameOfSquirrels
{
    public class Game : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly Dice _dice = new Dice();
        private Board _board;
        public List<IPawn> PlayerList;
        public List<ITile> BoardTiles;
        public int BoardWidth;
        public int BoardHeight;
        public bool PlayerFinishedMoving;
        private int _roundCounter;

        public int RoundCounter
        {
            get => _roundCounter;
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

        public void UpdatePawnLocation()
        {
            foreach (var item in PlayerList)
            {
                {
                    var ellipse = new Ellipse() { Height = 50, Width = 50, Margin = new System.Windows.Thickness(0, 0, 0, 15) };
                    var img = new BitmapImage(new Uri(@"https://pngimg.com/uploads/squirrel/squirrel_PNG15804.png"));
                    var image = new ImageBrush { ImageSource = img, Stretch = Stretch.Fill };
                    ellipse.Fill = image;
                    GridGame.Children.Add(ellipse);
                    Grid.SetColumn(ellipse, item.LocationX);
                    Grid.SetRow(ellipse, item.LocationY);
                }
            }
        }

        public void GenerateBoard()
        {
            _board = new Board(GridGame, BoardHeight, BoardWidth);
            var img = new BitmapImage(new Uri(@"https://cdn.discordapp.com/attachments/809042663969652756/810496380548284476/Backgroundtest_-_demo1.png"));
            var image = new ImageBrush { ImageSource = img };
            GridGame.Background = image;
            GenerateTiles();
            GeneratePawns();
        }

        private void GeneratePawns()
        {
            var pawnFactory = new PawnFactory();
            PlayerList = pawnFactory.CreatePawns(2);
        }

        private void GenerateTiles()
        {
            var tileFactory = new TileFactory();
            BoardTiles = tileFactory.CreateTiles(BoardHeight, BoardWidth);
            foreach (var tile in BoardTiles)
            {
                GridGame.Children.Add(tile.TileBorder);
                Grid.SetColumn(tile.TileBorder, tile.LocationX);
                Grid.SetRow(tile.TileBorder, tile.LocationY);
            }
        }

        public void DoTurn()
        {
            PlayerList[CurrentPlayer].IsReversed = false;
            CheckPlayerDirection();
            PlayerFinishedMoving = false;

            if (!PlayerList[CurrentPlayer].IsSkippingNextTurn)
            {
                var dice1 = new Dice();
                var roll = dice1.RollDice(1, 7);
                var roll2 = dice1.RollDice(1, 7);
                LastNumberRolled = roll + roll2;
                MovePawn(LastNumberRolled);
            }
            else
            {
                MessageBox.Show("Turn skipped");
                PlayerList[CurrentPlayer].TurnsToSkip -= 1;
                if (PlayerList[CurrentPlayer].TurnsToSkip == 0)
                {
                    PlayerList[CurrentPlayer].IsSkippingNextTurn = false;
                }
                PlayerFinishedMoving = true;
            }

            NextTurn();
        }

        public void ClearEllipsesFromGrid()
        {
            for (int i = 0; i < GridGame.Children.Count; i++)
            {
                if (GridGame.Children[i] is Ellipse)
                {
                    GridGame.Children.RemoveAt(i);
                }
            }
        }

        private void MovePawn(int roll)
        {
            for (var i = 1; i < roll + 1; i++)
            {
                if (i == roll)
                {
                    PlayerFinishedMoving = true;
                }

                MoveOnBoard();
                ClearEllipsesFromGrid();
            }
            if (PlayerFinishedMoving)
            {
                CheckForSpecialTile();
                UpdatePawnLocation();
            }
        }

        private void NextTurn()
        {
            CurrentPlayer++;
            if (CurrentPlayer > PlayerList.Count - 1)
            {
                CurrentPlayer = 0;
                RoundCounter++;
            }
        }

        public void CheckForSpecialTile()
        {
            foreach (var tile in BoardTiles)
            {
                if (PlayerList[CurrentPlayer].LocationX == tile.LocationX && PlayerList[CurrentPlayer].LocationY == tile.LocationY)
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

                        case BearTrapTile:
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
            PlayerList[CurrentPlayer].GoingRight = true;
            PlayerList[CurrentPlayer].LocationX = 2;
            PlayerList[CurrentPlayer].LocationY = 6;
            PlayerList[CurrentPlayer].Move(0, 0);
        }

        private void InteractWithBeartrap()
        {
            PlayerList[CurrentPlayer].TurnsToSkip = 3;
            PlayerList[CurrentPlayer].IsSkippingNextTurn = true;
        }

        private void InteractWithTeleport()
        {
            PlayerList[CurrentPlayer].Move(_dice.RollDice(0, 8), _dice.RollDice(0, 8));
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
            PlayerList[CurrentPlayer].GoingRight = true;
            PlayerList[CurrentPlayer].LocationX = 0;
            PlayerList[CurrentPlayer].LocationY = 0;
            PlayerList[CurrentPlayer].Move(0, 0);
        }

        private void InteractWithBridge()
        {
            PlayerList[CurrentPlayer].Move(1, 1);
            PlayerList[CurrentPlayer].GoingRight = !PlayerList[CurrentPlayer].GoingRight;
        }

        private void MoveOnBoard()
        {
            if (PlayerList[CurrentPlayer].LocationX == BoardWidth - 1 && PlayerList[CurrentPlayer].IsReversed && PlayerList[CurrentPlayer].GoingRight) // Right turn reverse
            {
                PlayerList[CurrentPlayer].Move(0, -1);
                PlayerList[CurrentPlayer].GoingRight = false;
            }
            else if (PlayerList[CurrentPlayer].LocationX == 0 && PlayerList[CurrentPlayer].IsReversed && !PlayerList[CurrentPlayer].GoingRight) // Left turn reverse
            {
                PlayerList[CurrentPlayer].Move(0, -1);
                PlayerList[CurrentPlayer].GoingRight = true;
            }
            else if (PlayerList[CurrentPlayer].LocationX == BoardWidth - 1 && PlayerList[CurrentPlayer].GoingRight) // Right turn
            {
                PlayerList[CurrentPlayer].Move(0, 1);
                PlayerList[CurrentPlayer].GoingRight = false;
            }
            else switch (PlayerList[CurrentPlayer].LocationX)
                {
                    //If at start
                    case 0 when PlayerList[CurrentPlayer].LocationY == 0:
                        PlayerList[CurrentPlayer].GoingRight = true;
                        PlayerList[CurrentPlayer].Move(1, 0);
                        break;
                    //Go past the end
                    case 0 when PlayerList[CurrentPlayer].LocationY == BoardHeight - 1:
                        PlayerList[CurrentPlayer].Move(1, 0);
                        PlayerList[CurrentPlayer].GoingRight = true;
                        PlayerList[CurrentPlayer].IsReversed = true;
                        break;
                    // Left boardside turn
                    case 0 when !PlayerList[CurrentPlayer].GoingRight:
                        PlayerList[CurrentPlayer].Move(0, 1);
                        PlayerList[CurrentPlayer].GoingRight = true;
                        break;

                    default:
                        {
                            if (PlayerList[CurrentPlayer].GoingRight) // Move right
                            {
                                PlayerList[CurrentPlayer].Move(1, 0);
                            }
                            else // Move left
                            {
                                PlayerList[CurrentPlayer].Move(-1, 0);
                            }

                            break;
                        }
                }
        }

        public void CheckPlayerDirection()
        {
            PlayerList[CurrentPlayer].GoingRight = PlayerList[CurrentPlayer].LocationY % 2 == 0;
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