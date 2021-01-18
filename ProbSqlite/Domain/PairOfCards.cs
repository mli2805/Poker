namespace ProbSqlite
{
    public class PairOfCards
    {
        public int Id { get; set; }
        public Card First { get; set; }
        public Card Second { get; set; }
        public string PairString { get; set; }
        public Potential Potential { get; set; }

        public PairOfCards() {}
        public PairOfCards(Card first, Card second)
        {
            First = first;
            Second = second;
            PairString = $"{First} + {Second}";
        }

        public override string ToString()
        {
            return $"{First} + {Second}";
        }

        public bool IsEquipotent(PairOfCards other)
        {
            if (First.Kind != other.First.Kind || Second.Kind != other.Second.Kind) return false;
            if (First.Kind == Second.Kind) return true;
            return (First.Suit == Second.Suit && other.First.Suit == other.Second.Suit
                    || First.Suit != Second.Suit && other.First.Suit != other.Second.Suit);
        }
    }
}