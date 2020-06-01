using System;
using System.Collections.Generic;
using System.Text;

namespace DiceCalculatorTools
{
    public class RollModifier
    {
        public int Threshold;
        public int AdditionalCount;
        public DiceCompare CompareType;
        public bool Recursive;
        public int MaxOperations;
        protected ModifierType ModType;

        public RollModifier(int threshold, DiceCompare compareType, bool recursive, int additionalCount = 1, int maxOperations = 0)
        {
            Threshold = threshold;
            AdditionalCount = additionalCount;
            CompareType = compareType;
            MaxOperations = maxOperations;
            Recursive = recursive;
        }
    }
}
