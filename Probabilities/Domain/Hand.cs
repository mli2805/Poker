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
                result += card.ToString();
            return result;
        }

        private readonly int[] _kinds = new int[15]; 
        private readonly int[] _suits = new int[4];

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
            if (card.Kind == Kind.Ace) 
                _kinds[1]++;
            _suits[(int)card.Suit]++;
        }
    }
}
