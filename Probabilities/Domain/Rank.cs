namespace Probabilities
{
    /* 
      STRAIGHT - is a series of five cards that follow each other, but that are not of the same suit. 
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
}