using System;
using System.Collections.Generic;
using System.Text;

namespace DiceCalculatorTools
{
    public class RollParameter
    {
        public int Count;
        public int DieType;
        public ModifierType ModifierPriority;
        public List<RollModifier> RollModifiers;

        public RollParameter(int count, int dieType)
        {
            Count = count;
            DieType = dieType;
            RollModifiers = new List<RollModifier>();
        }

        public RollParameter(int count, int dieType, ModifierType priority)
            : this(count, dieType)
        {
            ModifierPriority = priority;
        }

        public RollParameter(int count, int dieType, ModifierType priority, List<RollModifier> rollModifiers)
            : this(count, dieType, priority)
        {
            RollModifiers.AddRange(rollModifiers);
        }

        public RollParameter(int count, int dieType, ModifierType priority, RollModifier rollModifier)
            : this(count, dieType, priority, new List<RollModifier>() { rollModifier })
        {
        }

        public RollParameter(int count, int dieType, ModifierType priority, bool reroll, bool explode)
            :this (count, dieType, priority)
        {
            if (reroll)
                RollModifiers.Add(new RerollModifier(dieType, dieType));
            if (explode)
                RollModifiers.Add(new ExplodeModifier(dieType, dieType));
        }
    }
}
