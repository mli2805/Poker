using System.Collections.Generic;
using System.Linq;
using ProbSqlite;

namespace Logic
{
    public static class EquipotentPairs
    {
        public static List<List<PairOfCards>> Get()
        {
            var result = new List<List<PairOfCards>>();

            foreach (int[] numbers in 52.GetCombinationsOf(2))
            {
                var first = numbers[0].ToCard();
                var second = numbers[1].ToCard();

                var pairOfCards = first.Kind <= second.Kind ? new PairOfCards(first, second) : new PairOfCards(second, first);
                var list = result.FirstOrDefault(li => li.First().IsEquipotent(pairOfCards));
                if (list == null)
                    result.Add(new List<PairOfCards>{pairOfCards});
                else
                    list.Add(pairOfCards);
            }
            return result;
        }
    }
}
