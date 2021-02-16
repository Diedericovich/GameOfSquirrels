using System.Collections.Generic;
using System.Windows.Controls;

using _GameOfSquirrels;

using NUnit.Framework;

namespace GameOfSquirrels.Test
{
    public class Tests
    {
        public Game game;
        public IPawn pawn;
        public List<IPawn> playerList;


        [SetUp]
        public void Setup()
        {
            game = new Game( );
        }

        [TestCase(1, 2)]
        [TestCase(2, 4)]
        [TestCase(5, 7)]
        [TestCase(9, 2)]
        public void MovePawn_WhenCalled_IsPlayerInCorrectLocation(int roll, int expectedLocationX)
        {
            //Arrange
            pawn = new Pawn(0, 0);
            game.LastNumberRolled = roll;
            game.BoardTiles.Add(new BridgeTile(1, 0));
            game.BoardTiles.Add(new SquirrelTile(2, 0));
            game.BoardTiles.Add(new CatapultTile(5, 0));
            game.BoardTiles.Add(new SquirrelTile(6, 1));

            //Act
            game.MovePawn(roll, pawn);
            //Assert
            Assert.AreEqual(expectedLocationX, pawn.LocationX);
        }

        [Test]
        public void MovePawn_WhenLandingOnBearTrap_IsPlayerSkipTurnTrue()
        {
            pawn = new Pawn(0, 0);
            game.BoardTiles.Add(new BearTrapTile(1, 0));
            game.MovePawn(1, pawn);
            Assert.IsTrue(pawn.IsSkippingNextTurn);
        }
    }
}