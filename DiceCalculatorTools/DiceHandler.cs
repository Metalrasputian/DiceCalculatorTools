using System;
using System.Collections.Generic;

namespace DiceCalculatorTools
{
    enum DiceCompare
    { 
        Greater,
        Less
    }

    struct RollParameter
    {
        public int Count;
        public int DieType;
    }

    public class DiceHandler
    {
        public List<int> Roll(RollParameter rollParameters)
        {
            List<int> results = new List<int>();

            for (int i = 0; i < rollParameters.Count; ++i)
            { 
                
            }

            return results;
        }
    }
}
