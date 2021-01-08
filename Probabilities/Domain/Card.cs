namespace Probabilities
{
    public class Card
    {
        public readonly Suit Suit;
        public readonly Kind Kind;

        public Card(Suit suit, Kind kind)
        {
            Suit = suit;
            Kind = kind;
        }

        public override string ToString()
        {
            return $"{Kind} of {Suit}";
        }

        public bool Equals(Card other)
        {
            return Suit == other.Suit && Kind == other.Kind;
        }
    }

    public enum Kind
    {
        BadAce = 1,
        Two    = 2,
        Three  = 3,
        Four   = 4,
        Five   = 5,
        Six    = 6,
        Seven  = 7,
        Eight  = 8,
        Nine   = 9,
        Ten   = 10,
        Jack  = 11,
        Queen = 12,
        King  = 13,
        Ace   = 14,
    }

    public enum Suit
    {
        Spades   = 0,
        Clubs    = 1,
        Diamonds = 2,
        Hearts   = 3,
    }
}
