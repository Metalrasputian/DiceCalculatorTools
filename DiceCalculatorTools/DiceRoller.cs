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

        public List<RollResult> Roll(int count, int dieType)
        {
            List<RollResult> results = new List<RollResult>();

            var rnd = new Random();

            for (int i = 0; i < count; ++i)
                results.Add(new RollResult(rnd.Next(1, dieType + 1), new RollParameter(count, dieType)));

            return results;
        }

        public List<RollResult> Roll(RollParameter rollParameters)
        {
            return Roll(rollParameters.Count, rollParameters.DieType);
        }

        public List<RollResult> Roll(IEnumerable<RollParameter> rollParameterCollection)
        {
            List<RollResult> results = new List<RollResult>();

            foreach (RollParameter rollParam in rollParameterCollection)
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
