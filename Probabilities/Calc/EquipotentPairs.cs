using System.Collections.Generic;
using System.Linq;

namespace Probabilities
{
    public class PairOfCards
    {
        public Card First;
        public Card Second;

        public PairOfCards(Card first, Card second)
        {
            First = first;
            Second = second;
        }

        public override string ToString()
        {
            return $"{First} + {Second}";
        }

        public bool IsEquipotent(PairOfCards other)
        {
            if (First.Kind != other.First.Kind || Second.Kind != other.Second.Kind) return false;
            if (First.Kind == Second.Kind) return true;
            return (First.Suit == Second.Suit && other.First.Suit == other.Second.Suit
                    || First.Suit != Second.Suit && other.First.Suit != other.Second.Suit);
        }
    }

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
