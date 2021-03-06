﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DiceCalculatorTools
{
    public class RollResult
    {
        public DicePool RollParam;
        public int Result;
        public bool Exploded;
        public bool FromExplode;
        public bool Rerolled;
        public bool FromReroll;

        public RollResult(int result, DicePool rollParam, bool exploded = false, bool fromExplode = false, bool rerolled = false, bool fromReroll = false)
        {
            Result = result;
            RollParam = rollParam;
            Exploded = exploded;
            FromExplode = fromExplode;
            Rerolled = rerolled;
            FromReroll = fromReroll;
        }

        public override string ToString()
        {
            string output = "";

            if (Exploded)
                output += "d!";
            else
                output += "d";

            return output + RollParam.DieType + ": " + Result;
        }
    }
}
