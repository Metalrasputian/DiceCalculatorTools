using System;
using System.Collections.Generic;
using DiceCalculatorTools;

namespace DiceToolTester
{
    class Program
    {
        static void Main(string[] args)
        {
            DiceRoller dh = new DiceRoller();

            List<RollParameter> rollParams = new List<RollParameter>() { new RollParameter(3, 6), new RollParameter(4, 8) };

            List<RollResult> rolls = dh.Roll(rollParams);

            foreach (RollResult roll in rolls)
            {
                Console.Write(roll.ToString() + ", ");
            }
        }
    }
}
