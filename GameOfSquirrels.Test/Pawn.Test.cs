using System;
using System.Collections.Generic;
using System.Text;
using _GameOfSquirrels;
using NUnit.Framework;

namespace GameOfSquirrels.Test
{
    class PawnTest
    {
        public Pawn pawn;

        [SetUp]
        public void Setup()
        {
            pawn = new Pawn(0,0);
            
        }

        [TestCase(3,3)]
        public void Move_WhenChangingLocationX_CheckIfLocationCorrect(int move, int expectedLocation)
        {
            // ARRANGE


            // ACT
            pawn.Move(move, 0);

            // ASSERT
            Assert.AreEqual(pawn.LocationX, expectedLocation);
        }

    }
}
