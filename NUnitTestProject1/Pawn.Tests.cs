using _GameOfSquirrels;

using NUnit.Framework;

namespace GameOfSquirrel.Testing
{
    namespace GameOfSquirrel.Testing
    {
        [TestFixture()]
        public class PawnTests
        {
            public IPawn Pawn;

            [SetUp]
            public void SetUp()
            {
                Pawn = new Pawn(0, 0);
            }

            [TestCase(3, 3)]
            public void Move_WhenCalled_IsCorrect(int move, int expectedLocationX)
            {
                Pawn.Move(move, 0);
                Assert.AreEqual(Pawn.LocationX, expectedLocationX);
            }

            [Test()]
            public void GenerateBoardTest()
            {
            }

            [Test()]
            public void MovePawnTest()
            {
            }

            [Test()]
            public void DoTurnTest()
            {
            }
        }
    }
}