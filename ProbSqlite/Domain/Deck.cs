using System;
using System.Collections.Generic;
using System.Linq;

namespace ProbSqlite
{
    public static class Deck
    {
        public static Card[] CardsInOrder;

        static Deck()
        {
            //                              Id = index + 1
            CardsInOrder = Enumerable.Range(0, 52).Select(i => new Card(i)).ToArray();
        }

        public static void Load(ProbContext db)
        {
            CardsInOrder = db.Cards.ToArray();
        }

        /// <summary>
        /// converts number to Card
        /// </summary>
        /// <param name="number">from range 1..52</param>
        /// <returns></returns>
        public static Card ToCard(this int number)
        {
            number--;
            return CardsInOrder[number];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">0..51</param>
        /// <returns></returns>
        public static Card ById(this int id)
        {
            return CardsInOrder[id];
        }

        public static Stack<Card> Shuffle()
        {
            Stack<Card> shuffledCards = new Stack<Card>();
            Random rng = new Random();
            HashSet<int> occupied = new HashSet<int>();
            while (occupied.Count < 52)
            {
                var n = rng.Next(52);
                if (occupied.Add(n))
                    shuffledCards.Push(CardsInOrder[n]);
            }

            return shuffledCards;
        }

        public static Card[] GetCardsExcluding(PairOfCards first, PairOfCards second)
        {
            return CardsInOrder.Where(c => !c.Equals(first.First)
                                           && !c.Equals(first.Second)
                                           && !c.Equals(second.First)
                                           && !c.Equals(second.Second)).ToArray();
        }
    }
}
