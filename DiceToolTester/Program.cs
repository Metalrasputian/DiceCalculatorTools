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

            //List<RollParameter> rollParams = new List<RollParameter>() { new RollParameter(3, 6, ModifierType.Explode, new ExplodeModifier(6, 6)), new RollParameter(4, 8) };

            DicePool rollParam = new DicePool(6, 6, ModifierType.Explode, new ExplodeModifier(6, 6, 2));

            List<RollResult> rolls = dh.Roll(rollParam);

            rolls.AddRange(dh.Explode(rolls, rollParam.RollModifiers[0] as ExplodeModifier));

            foreach (RollResult roll in rolls)
            {
                if (roll.Exploded)
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (roll.FromExplode)
                    Console.ForegroundColor = ConsoleColor.Yellow;

                Console.Write(roll.ToString() + ", ");

                Console.ResetColor();
            }
        }
    }
}
