using _GameOfSquirrels;
using NUnit.Framework;

namespace GameOfSquirrel.Testing
{
    [TestFixture()]
    public class PawnTests
    {
        public IPawn pawn;

        [SetUp]
        public void SetUp()
        {
            pawn = new Pawn(0, 0);
        }

        [TestCase(3, 3)]
        public void Move_WhenCalled_IsCorrect(int move, int expectedLocationX)
        {
            pawn.Move(move, 0);
            Assert.AreEqual(pawn.LocationX, expectedLocationX);
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