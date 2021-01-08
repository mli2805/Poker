﻿namespace Probabilities
{
    /* 
     STRAIGHT - is a series of five cards that follow each other, but that are not of the save suit. 
         Aces can follow a king or start a straight followed by a two
     FLUSH - is when all cards are of one suit 
     FULL_HOUSE - 3 + 2
     STRAIGHT_FLUSH - straight + flush
     ROYAL_FLUSH - this is a straight flush from 10 to Ace
     */
    public enum CombinationName
    {
        HighCard       = 1,
        OnePair        = 2,
        TwoPairs       = 3,
        ThreeOfAKind   = 4,
        Straight       = 5,   
        Flush          = 6,      
        FullHouse      = 7,  
        FourOfAKind    = 8,
        StraightFlush  = 9,
        RoyalFlush    = 10,  
    }
    
    public class Combination
    {
        public CombinationName Rank;
        public Card[] Cards;
    }


    // RoyalFlush is just a StraightFlush started from 10
    public class StraightFlush : Combination
    {
        public Kind KindOfMinorCard;

        public StraightFlush(Card[] cards, Kind kindOfMinorCard)
        {
            Rank = CombinationName.StraightFlush;
            Cards = cards;
            KindOfMinorCard = kindOfMinorCard;
        }
    }

    public class FourOfAKind : Combination
    {
        public Kind KindOfMainCard;
        public Kind KindOfFifthCard;

        public FourOfAKind(Card[] cards, Kind kindOfMainCard, Kind kindOfFifthCard)
        {
            Rank = CombinationName.FourOfAKind;
            Cards = cards;
            KindOfMainCard = kindOfMainCard;
            KindOfFifthCard = kindOfFifthCard;
        }
    }

    public class Straight : Combination
    {
        public Kind KindOfMinorCard;

        public Straight(Card[] cards, Kind kindOfMinorCard)
        {
            Rank = CombinationName.StraightFlush;
            Cards = cards;
            KindOfMinorCard = kindOfMinorCard;
        }
    }

    public class HighCard : Combination
    {
        public HighCard(Card[] cards)
        {
            Rank = CombinationName.HighCard;
            Cards = cards;
        }
    }
}
