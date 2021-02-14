using System;

namespace _GameOfSquirrels
{
    public class Dice
    {
        private Random dice = new Random();

        public int RollDice(int bottom, int top)
        {
            int result = dice.Next(bottom, top);

            return result;
        }
    }
}