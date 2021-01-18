namespace ProbSqlite
{
    public class Card
    {
        public int Id { get; set; }
        public Suit Suit  { get; set; }
        public Kind Kind  { get; set; }

        public Card(Suit suit, Kind kind)
        {
            Id = (int) suit * 13 + (int) kind + 1;
            Suit = suit;
            Kind = kind;
        }

        public Card(int number)
        {
            Id = number + 1;
            Suit = (Suit)(number / 13);
            Kind = (Kind)(number % 13);
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
