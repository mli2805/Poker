using System.Collections.Generic;

namespace Probabilities
{
    public class Combination
    {
        public Rank Rank;
        public List<Card> Cards; // 5 highest cards 

        public Combination(Rank rank, List<Card> cards)
        {
            Rank = rank;
            Cards = cards;
        }

        public int CompareTo(Combination other)
        {
            var cmp = Rank.CompareTo(other.Rank);
            if (cmp != 0) return cmp;

            for (int i = 0; i <= 4; i++)
            {
                cmp = Cards[i].Kind.CompareTo(other.Cards[i].Kind);
                if (cmp != 0) return -cmp;
            }

            return 0;
        }
    }
}
