using System;
using System.Collections.Generic;
using System.Text;

namespace DiceCalculatorTools
{
    public class RollModifier
    {
        public int Threshold;
        public int AdditionalCount;
        public int AdditionalType;
        public DiceCompare CompareType;
        public bool Recursive;
        public int MaxOperations;
        protected ModifierType ModType;

        public RollModifier(int threshold, int additionalType, DiceCompare compareType, int additionalCount = 1,  bool recursive = false,  int maxOperations = 0)
        {
            Threshold = threshold;
            AdditionalCount = additionalCount;
            AdditionalType = additionalType;
            CompareType = compareType;
            MaxOperations = maxOperations;
            Recursive = recursive;
        }
    }
}
