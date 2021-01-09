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
        Ace        = 0,
        King       = 1,
        Queen      = 2,
        Jack       = 3,
        Ten        = 4,
        Nine       = 5,
        Eight      = 6,
        Seven      = 7,
        Six        = 8,
        Five       = 9,
        Four      = 10,
        Three     = 11,
        Two       = 12,
        LowerAce  = 13,
    }

    public enum Suit
    {
        Spades = 0,
        Clubs = 1,
        Diamonds = 2,
        Hearts = 3,
    }
}
