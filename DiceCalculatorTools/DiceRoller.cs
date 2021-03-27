using System;
using System.Collections.Generic;

namespace DiceCalculatorTools
{
    public enum DiceCompare
    { 
        Greater,
        Less
    }

    public enum ModifierType
    { 
        Explode,
        Reroll
    }

    public class DiceRoller
    {
        
        #region Standard Roll

        //<summary>Rolls a supplied number of indicated dice
        //</summary>
        //<param name="count">The number of dice being rolled</param>
        //<param name="dieType">The die type being rolled, I.E. 20 for a d20</param>
        public List<RollResult> Roll(int count, int dieType)
        {
            List<RollResult> results = new List<RollResult>();

            var rnd = new Random();

            for (int i = 0; i < count; ++i)
                results.Add(new RollResult(rnd.Next(1, dieType + 1), new DicePool(count, dieType)));

            return results;
        }

        //<summary>Rolls a supplied pool of dice
        //</summary>
        //<param name="dicePool">The pool of dice to be rolled</param>
        public List<RollResult> Roll(DicePool dicePool)
        {
            return Roll(dicePool.Count, dicePool.DieType);
        }


        //<summary>Rolls a supplied list of dice pools
        //</summary>
        //<param name="dicePools">The list of pools of dice to be rolled</param>
        public List<RollResult> Roll(IEnumerable<DicePool> dicePools)
        {
            List<RollResult> results = new List<RollResult>();

            foreach (DicePool rollParam in dicePools)
                results.AddRange(Roll(rollParam));

            return results;
        }
        #endregion

        #region Exploding Roll


        public List<RollResult> Explode(List<RollResult> incomingRollResults, ExplodeModifier modifier, int currentOperationCount = 0)
        {
            List<RollResult> results = new List<RollResult>();

            foreach (RollResult roll in incomingRollResults)
            {
                List<RollResult> localResults = new List<RollResult>();

                if (roll.Result >= modifier.Threshold)
                {
                    roll.Exploded = true;
                    localResults.AddRange(Roll(modifier.AdditionalCount, modifier.AdditionalType));

                    foreach (RollResult localRoll in localResults)
                        localRoll.FromExplode = true;

                    results.AddRange(localResults);

                    if (modifier.Recursive)
                    {
                        if (modifier.MaxOperations > 0)
                        {
                            if (modifier.MaxOperations > currentOperationCount)
                            {
                                ++currentOperationCount;

                                results.AddRange(Explode(localResults, modifier, currentOperationCount));
                            }
                        }
                        else 
                        {
                            results.AddRange(Explode(localResults, modifier));
                        }
                    }
                }
            }

            return results;
        }

        #endregion
    }
}
