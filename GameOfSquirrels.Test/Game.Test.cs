using System.Windows.Controls;

using _GameOfSquirrels;

using NUnit.Framework;

namespace GameOfSquirrels.Test
{
    public class Tests
    {
        public Game game;
        public MainWindow mainWindow;

        [SetUp]
        public void Setup()
        {
            mainWindow = new MainWindow();
            game = new Game(new Grid());
        }

        [TestCase(1, 0, 3)]
        public void MovePawn_WhenCalled_IsPlayerInCorrectLocation(int roll, int expectedLocationY, int expectedLocationX)
        {
            //Arrange
            game.BoardTiles.Add(new BridgeTile(1, 0));
            game.BoardTiles.Add(new SquirrelTile(2, 0));
            game.BoardTiles.Add(new CatapultTile(5, 0));
            game.BoardTiles.Add(new SquirrelTile(6, 1));
            game.PlayerList.Add(new Pawn(0, 0));
            game.CurrentPlayer = 0;
            //Act
            game.MovePawn(roll);
            //Assert
            Assert.AreEqual(game.PlayerList[game.CurrentPlayer].LocationX, expectedLocationX);
        }
    }
}