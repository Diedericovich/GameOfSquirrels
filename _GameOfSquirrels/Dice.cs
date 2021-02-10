using System;
using System.Collections.Generic;
using System.Text;

namespace _GameOfSquirrels
{
    class Dice
    {
        Random dice = new Random();

        public int RollDice(int bottom, int top)
        {
            int result = dice.Next(bottom,top);

            return result;
        }
    }
}
