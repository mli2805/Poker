using System.Collections.Generic;
using System.Linq;

namespace Probabilities
{
    public class Player
    {
        public string Name;
        public Hand Hand;

        public Player(string name, Hand hand)
        {
            Name = name;
            Hand = hand;
        }

        public int CompareTo(Player other)
        {
            return Hand.CompareTo(other.Hand);
        }

        private readonly int[] _chancesForEachRank = new int[10];

        public void Calc(List<Card> cardsInDeck)
        {
            var emptyPlaces = 7 - Hand.Cards.Count;

            var plus = cardsInDeck.Take(emptyPlaces);
            Hand.AddCards(plus.ToList());

            _chancesForEachRank[(int) Hand.Combination.Rank]++;
        }
     
    }
}
