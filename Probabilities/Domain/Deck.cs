using System;
using System.Collections.Generic;

namespace Probabilities
{
    public class Deck
    {
        public readonly Stack<Card> ShuffledCards = new Stack<Card>();

        public Deck()
        {
            Random rng = new Random();
            HashSet<int> occupied = new HashSet<int>();
            while (occupied.Count < 52)
            {
                var n = rng.Next(52);
                if (occupied.Add(n))
                    ShuffledCards.Push(n.ToCard());
            }
        }
    }
}
