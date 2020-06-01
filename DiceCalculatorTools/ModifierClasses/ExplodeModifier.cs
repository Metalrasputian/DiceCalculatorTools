using System;
using System.Collections.Generic;
using System.Text;

namespace DiceCalculatorTools
{
    public class ExplodeModifier : RollModifier
    {
        public ExplodeModifier(int threshold, DiceCompare compareType = DiceCompare.Greater, bool recursive = false, int additionalCount = 1, int maxOperations = 0)
            :base(threshold, compareType, recursive, additionalCount, maxOperations)
        {
        }
    }
}
