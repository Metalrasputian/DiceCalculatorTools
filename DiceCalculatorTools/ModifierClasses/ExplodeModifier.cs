using System;
using System.Collections.Generic;
using System.Text;

namespace DiceCalculatorTools
{
    public class ExplodeModifier : RollModifier
    {
        public ExplodeModifier(int threshold, int additionalType, int additionalCount = 1, DiceCompare compareType = DiceCompare.Greater, bool recursive = false,  int maxOperations = 0)
            :base(threshold, additionalType, compareType, additionalCount, recursive, maxOperations)
        {
        }
    }
}
