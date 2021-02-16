using _GameOfSquirrels;

using NUnit.Framework;

namespace GameOfSquirrels.Test
{
    internal class PawnTest
    {
        public Pawn Pawn;

        [SetUp]
        public void Setup()
        {
            Pawn = new Pawn(0, 0);
        }

        [TestCase(3, 3)]
        [TestCase(8, 6)]
        [TestCase(3, 3)]
        public void Move_WhenChangingLocation_CheckIfLocationCorrect(int move, int expectedLocation)
        {
            // ARRANGE

            // ACT
            Pawn.Move(move, 0);

            // ASSERT
            Assert.AreEqual(Pawn.LocationX, expectedLocation);
        }
    }
}