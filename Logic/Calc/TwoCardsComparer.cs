using System.Collections.Generic;
using System.Linq;
using ProbSqlite;

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
        public static PairToPairBattle Compare(this PairOfCards first, PairOfCards second)
        {
            // var deck = GetDeckWithoutTwoPairs(first, second);
            var deck = Deck.GetCardsExcluding(first, second);

            var wins = 0;
            var draws = 0;
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

                if (dist == 0)
                {
                    draws++;
                }
                if (dist == -1)
                {
                    loses++;
                }
            }
            return new PairToPairBattle(first, second, wins, draws, loses);
        }
        
    }
}
