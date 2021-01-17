namespace Logic
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
}
