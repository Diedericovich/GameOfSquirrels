using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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
        public ObservableCollection<IPawn> PlayerList = new ObservableCollection<IPawn>();
        public List<ITile> BoardTiles = new List<ITile>();
        private readonly int _boardWidth;
        private readonly int _boardHeight;
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

        public Game()
        {
            _boardWidth = 8;
            _boardHeight = 8;
            CurrentPlayer = 0;
        }

        public void StartGame(Grid grid, int players)
        {
            GridGame = grid;
            GenerateBoard();
            GenerateTiles();
            GeneratePawns(players);
        }

        private void GenerateBoard()
        {
            _board = new Board(GridGame, _boardHeight, _boardWidth);
            var img = new BitmapImage(new Uri(@"https://cdn.discordapp.com/attachments/809042663969652756/810496380548284476/Backgroundtest_-_demo1.png"));
            var image = new ImageBrush { ImageSource = img };
            GridGame.Background = image;
        }

        private void GeneratePawns(int players)
        {
            var pawnFactory = new PawnFactory();
            PlayerList = pawnFactory.CreatePawns(players);
            PlacePawnsOnBoard();
        }

        private void GenerateTiles()
        {
            var tileFactory = new TileFactory();
            BoardTiles = tileFactory.CreateTiles(_boardHeight, _boardWidth);
            foreach (var tile in BoardTiles)
            {
                Border border = new Border() { Height = 60, Width = 35 };
                var img = new BitmapImage(new Uri(tile.Image));
                var image = new ImageBrush { ImageSource = img, Stretch = Stretch.Fill };
                border.Background = image;
                Grid.SetColumn(border, tile.LocationX);
                Grid.SetRow(border, tile.LocationY);
                GridGame.Children.Add(border);
            }
        }

        private void PlacePawnsOnBoard()
        {
            foreach (var item in PlayerList)
            {
                var square = new Rectangle() { Margin = new Thickness(0, 0, 0, 15) };
                var img = new BitmapImage(new Uri(item.Image));
                var image = new ImageBrush { ImageSource = img, Stretch = Stretch.Fill };
                square.Fill = image;

                Binding bindingY = new Binding("LocationY");
                bindingY.Source = item;
                square.SetBinding(Grid.RowProperty, bindingY);
                Binding bindingX = new Binding("LocationX");
                bindingX.Source = item;
                square.SetBinding(Grid.ColumnProperty, bindingX);
                Binding bindingSize = new Binding("Size");
                bindingSize.Source = item;
                square.SetBinding(Rectangle.HeightProperty, bindingSize);
                square.SetBinding(Rectangle.WidthProperty, bindingSize);
                GridGame.Children.Add(square);
            }
        }

        public void DoTurn()
        {
            PlayerList[CurrentPlayer].IsReversed = false;
            CheckPlayerDirection(PlayerList[CurrentPlayer]);
            PlayerFinishedMoving = false;

            if (!PlayerList[CurrentPlayer].IsSkippingNextTurn)
            {
                var dice1 = new Dice();
                var roll = dice1.RollDice(1, 7);
                var roll2 = dice1.RollDice(1, 7);
                LastNumberRolled = roll + roll2;
                MovePawn(LastNumberRolled, PlayerList[CurrentPlayer]);
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

        public async void MovePawn(int roll, IPawn pawn)
        {
            for (var i = 1; i < roll + 1; i++)
            {
                if (i == roll)
                {
                    PlayerFinishedMoving = true;
                }
                await Task.Delay(300);
                MoveOnBoard(pawn);
            }
            if (PlayerFinishedMoving)
            {
                CheckForSpecialTile(pawn);
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

        private void CheckForSpecialTile(IPawn pawn)
        {
            foreach (var tile in BoardTiles.Where(tile => pawn.LocationX == tile.LocationX && pawn.LocationY == tile.LocationY))
            {
                MessageBox.Show(tile.GetInteractionMessage());
                switch (tile)
                {
                    case BridgeTile:
                        InteractWithBridge(pawn);
                        break;

                    case FireTile:
                        InteractWithFire(pawn);
                        break;

                    case SquirrelTile:
                        InteractWithSquirrel(pawn);
                        break;

                    case CatapultTile:
                        InteractWithCatapult(pawn);
                        break;

                    case EndGameTile:
                        InteractWithEndGame(pawn);
                        break;

                    case TeleportTile:
                        InteractWithTeleport(pawn);
                        break;

                    case BearTrapTile:
                        InteractWithBeartrap(pawn);
                        break;

                    case TunnelTile:
                        InteractWithTunnel(pawn);
                        break;
                }
            }
        }

        private void InteractWithTunnel(IPawn pawn)
        {
            pawn.GoingRight = true;
            pawn.LocationX = 2;
            pawn.LocationY = 6;
            pawn.Move(0, 0);
        }

        private void InteractWithBeartrap(IPawn pawn)
        {
            pawn.TurnsToSkip = 3;
            pawn.IsSkippingNextTurn = true;
        }

        private void InteractWithTeleport(IPawn pawn)
        {
            pawn.Move(_dice.RollDice(0, 8), _dice.RollDice(0, 8));
            CheckPlayerDirection(pawn);
        }

        private void InteractWithEndGame(IPawn pawn)
        {
            EndGame();
        }

        private void InteractWithCatapult(IPawn pawn)
        {
            PlayerFinishedMoving = false;
            MovePawn(3, pawn);
        }

        private void InteractWithSquirrel(IPawn pawn)
        {
            PlayerFinishedMoving = false;
            MovePawn(LastNumberRolled, pawn);
        }

        private void InteractWithFire(IPawn pawn)
        {
            pawn.GoingRight = true;
            pawn.LocationX = 0;
            pawn.LocationY = 0;
            pawn.Move(0, 0);
        }

        private void InteractWithBridge(IPawn pawn)
        {
            pawn.Move(1, 1);
            pawn.GoingRight = !pawn.GoingRight;
        }

        private void MoveOnBoard(IPawn pawn)
        {
            if (pawn.LocationX == _boardWidth - 1 && pawn.IsReversed && pawn.GoingRight) // Right turn reverse
            {
                pawn.Move(0, -1);
                pawn.GoingRight = false;
            }
            else if (pawn.LocationX == 0 && pawn.IsReversed && !pawn.GoingRight) // Left turn reverse
            {
                pawn.Move(0, -1);
                pawn.GoingRight = true;
            }
            else if (pawn.LocationX == _boardWidth - 1 && pawn.GoingRight) // Right turn
            {
                pawn.Move(0, 1);
                pawn.GoingRight = false;
            }
            else switch (pawn.LocationX)
                {
                    //If at start
                    case 0 when pawn.LocationY == 0:
                        pawn.GoingRight = true;
                        pawn.Move(1, 0);
                        break;
                    //Go past the end
                    case 0 when pawn.LocationY == _boardHeight - 1:
                        pawn.Move(1, 0);
                        pawn.GoingRight = true;
                        pawn.IsReversed = true;
                        break;
                    // Left boardside turn
                    case 0 when !pawn.GoingRight:
                        pawn.Move(0, 1);
                        pawn.GoingRight = true;
                        break;

                    default:
                        {
                            if (pawn.GoingRight) // Move right
                            {
                                pawn.Move(1, 0);
                            }
                            else // Move left
                            {
                                pawn.Move(-1, 0);
                            }

                            break;
                        }
                }
        }

        private void CheckPlayerDirection(IPawn pawn)
        {
            pawn.GoingRight = pawn.LocationY % 2 == 0;
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