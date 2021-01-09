using System.Collections.Generic;

namespace Probabilities
{
    public partial class Hand
    {
        public readonly List<Card> Cards = new List<Card>();
        public override string ToString()
        {
            var result = "";
            foreach (var card in Cards)
                result += card + " ; ";
            return result;
        }

        private readonly int[] _kinds = new int[13]; // number of cards of every kind from Ace (index 0) to Two (index 12)
        private readonly int[] _suits = new int[4]; // number of cards of every suit

        public Combination Combination;

        public void AddCards(List<Card> cards)
        {
            foreach (var card in cards) AddOneCard(card);
            Combination = IdentifyCombination();
        }

        private void AddOneCard(Card card)
        {
            Cards.Add(card);
            _kinds[(int)card.Kind]++;
            _suits[(int)card.Suit]++;
        }

        public int CompareTo(Hand other)
        {
            return Combination.CompareTo(other.Combination);
        }
    }
}
