using System.Collections.Generic;
using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using _GameOfSquirrels.Tiles;
using System.Windows.Media;

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
        public int RoundCounter { get; set; }
        public int LastNumberRolled { get; set; }

        public Grid GridGame { get; set; }

        public int CurrentPlayer { get; set; }

        public Game(Grid gridGame)
        {
            BoardWidth = 40;
            BoardHeight = 4;
            GridGame = gridGame;
            //GridGame.Height = BoardHeight * 25;
            CurrentPlayer = 0;
        }

        public void GenerateBoard()
        {
            board = new Board(GridGame, BoardHeight, BoardWidth);
            //GridGame.ShowGridLines = true;
            //GridGame.Background = new SolidColorBrush(Color.FromRgb(0,115,21));
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

        public void MovePawn(int move)
        {
            Playerlist[CurrentPlayer].Move(move);
            foreach (ITile tile in BoardTiles)
            {
                if (Playerlist[CurrentPlayer].LocationX == tile.LocationX && Playerlist[CurrentPlayer].LocationY == tile.LocationY)
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

        /// <summary>
        /// </summary>
        public List<ITile> tiles;

        public int maxCatapult = 5;
        public int maxFire = 0;
        public int maxBridge = 5;
        public int howManyNormal = 30;

        private int _normalTileCount;
        private int _catapultTileCount;
        private int _fireTileCount;
        private int _bridgeTileCount;
        private int _tileToGenerate = 0;
        private int _resetHowManyWhite;

        private void LoadMap()
        {
            _bridgeTileCount = 0;
            _catapultTileCount = 0;
            _fireTileCount = 0;
            _normalTileCount = 0;

            for (int i = 0; i < board.MaxBoardHeight; i++)
            {
                for (int j = 0; j < board.MaxBoardWidth; j++)
                {
                    _tileToGenerate = 1;
                    CheckTile(_tileToGenerate);

                    //if (x >= 0 && x < 3 && y >= 0 && y < 3)
                    //{
                    //    tileToGenerate = 1;
                    //    CheckTile(tileToGenerate);
                    //    GameObject obj;
                    //    obj = Instantiate(tiles[tileToGenerate], new Vector3(x, 0, y), Quaternion.identity);
                    //    obj.transform.parent = transform;
                    //}
                }
            }
        }

        private void CheckTile(int randomTile)
        {
            switch (randomTile)
            {
                case 1:
                    if (_catapultTileCount >= maxCatapult - 1)
                    {
                        _tileToGenerate = 1;
                        _normalTileCount++;
                        howManyNormal--;
                        break;
                    }
                    else
                    {
                        if (howManyNormal <= 0)
                        {
                            _catapultTileCount++;
                            howManyNormal = _resetHowManyWhite;
                            break;
                        }
                        else
                        {
                            _tileToGenerate = 1;
                            _normalTileCount++;
                            howManyNormal--;
                            break;
                        }
                    }

                case 2:
                    _normalTileCount++;
                    howManyNormal--;
                    break;

                case 3:
                    if (_bridgeTileCount >= maxBridge)
                    {
                        _tileToGenerate = 1;
                        _normalTileCount++;
                        howManyNormal--;
                        break;
                    }
                    else
                    {
                        _bridgeTileCount++;
                        break;
                    }

                default:
                    _normalTileCount++;
                    howManyNormal--;
                    break;
            }
        }
    }
}