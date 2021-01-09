namespace Probabilities
{
    /* 
     STRAIGHT - is a series of five cards that follow each other, but that are not of the save suit. 
         Aces can follow a king or start a straight followed by a two
     FLUSH - is when all cards are of one suit 
     FULL_HOUSE - 3 + 2
     STRAIGHT_FLUSH - straight + flush
     ROYAL_FLUSH - this is a straight flush from 10 to Ace
     */
    public enum Rank
    {
        HighCard = 1,
        OnePair = 2,
        TwoPairs = 3,
        ThreeOfAKind = 4,
        Straight = 5,
        Flush = 6,
        FullHouse = 7,
        FourOfAKind = 8,
        StraightFlush = 9,
        RoyalFlush = 10,
    }

    public class Combination
    {
        public Rank Rank;
        public Card[] Cards; // 5 highest cards 

        public Combination(Rank rank, Card[] cards)
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
                if (cmp != 0) return cmp;
            }

            return 0;
        }
    }
}
