using System.Collections.Generic;

using _GameOfSquirrels;

using NUnit.Framework;

namespace GameOfSquirrels.Test
{
    public class Tests
    {
        public Game Game;
        public IPawn Pawn;
        public List<IPawn> PlayerList;

        [SetUp]
        public void Setup()
        {
            Game = new Game();
        }

        [TestCase(1, 2)]
        [TestCase(2, 4)]
        [TestCase(5, 7)]
        [TestCase(9, 2)]
        public void MovePawn_WhenCalled_IsPlayerInCorrectLocation(int roll, int expectedLocationX)
        {
            //Arrange
            Pawn = new Pawn(0, 0);
            Game.LastNumberRolled = roll;
            Game.BoardTiles.Add(new BridgeTile(1, 0));
            Game.BoardTiles.Add(new SquirrelTile(2, 0));
            Game.BoardTiles.Add(new CatapultTile(5, 0));
            Game.BoardTiles.Add(new SquirrelTile(6, 1));

            //Act
            Game.MovePawn(roll, Pawn);
            //Assert
            Assert.AreEqual(expectedLocationX, Pawn.LocationX);
        }

        [Test]
        public void MovePawn_WhenLandingOnBearTrap_IsPlayerSkipTurnTrue()
        {
            Pawn = new Pawn(0, 0);
            Game.BoardTiles.Add(new BearTrapTile(1, 0));
            Game.MovePawn(1, Pawn);
            Assert.IsTrue(Pawn.IsSkippingNextTurn);
        }
    }
}