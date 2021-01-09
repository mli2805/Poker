using System.Collections.Generic;

namespace Probabilities
{
    public partial class Hand
    {
        private readonly List<Card> _cards = new List<Card>();
        public override string ToString()
        {
            var result = "";
            foreach (var card in _cards)
                result += card + " ; ";
            return result;
        }

        private readonly int[] _kinds = new int[14]; // number of cards of every kind 
        private readonly int[] _suits = new int[4]; // number of cards of every suit

        public Combination Combination;

        public void AddCards(Card[] cards)
        {
            foreach (var card in cards) AddOneCard(card);
            Combination = IdentifyCombination();
        }

        private void AddOneCard(Card card)
        {
            _cards.Add(card);
            _kinds[(int)card.Kind]++;
            _suits[(int)card.Suit]++;
        }

        public int CompareTo(Hand other)
        {
            return Combination.CompareTo(other.Combination);
        }
    }
}
