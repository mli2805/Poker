using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public static class TwoCardsComparer
    {
        /// <summary>
        /// returns balance (win minus lose) from 1 712 304 variants for the first pair of cards
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static int Compare(this PairOfCards first, PairOfCards second)
        {
            var deck = GetDeckWithoutTwoPairs(first, second);

            var wins = 0;
            var loses = 0;
            foreach (var numbers in 48.GetCombinationsOf(5))
            {
                var forFirst = new List<Card>() { first.First, first.Second };
                var forSecond = new List<Card>() { second.First, second.Second };

                var fiveCards = numbers.Select(number => deck[number-1]).ToList();

                forFirst.AddRange(fiveCards);
                forSecond.AddRange(fiveCards);

                var firstHand = new Hand();
                firstHand.AddCards(forFirst);
                var secondHand = new Hand();
                secondHand.AddCards(forSecond);

                var dist = firstHand.CompareTo(secondHand);
                if (dist == 1)
                {
                    wins++;
                }
                if (dist == -1)
                {
                    loses++;
                }
            }
            return wins - loses;
        }

        private static Card[] GetDeckWithoutTwoPairs(PairOfCards first, PairOfCards second)
        {
            var deck = GetDeck().ToList();
            var card = deck.First(c => c.Equals(first.First));
            deck.Remove(card);
            card = deck.First(c => c.Equals(first.Second));
            deck.Remove(card);
            card = deck.First(c => c.Equals(second.First));
            deck.Remove(card);
            card = deck.First(c => c.Equals(second.Second));
            deck.Remove(card);
            return deck.ToArray();
        }

        private static IEnumerable<Card> GetDeck()
        {
            foreach (var suit in (Suit[])Enum.GetValues(typeof(Suit)))
            {
                foreach (var kind in (Kind[])Enum.GetValues(typeof(Kind)))
                {
                    if (kind != Kind.LowerAce)
                        yield return new Card(suit, kind);
                }
            }
        }
    }
}
