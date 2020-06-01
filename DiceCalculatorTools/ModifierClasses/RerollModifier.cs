using System;
using System.Collections.Generic;
using System.Text;

namespace DiceCalculatorTools
{
    public class RerollModifier : RollModifier
    {
        public RerollModifier(int threshold, DiceCompare compareType = DiceCompare.Less, bool recursive = false, int additionalCount = 1,  int maxOperations = 0)
            :base(threshold, compareType, recursive, additionalCount, maxOperations)
        {
        }
    }
}
