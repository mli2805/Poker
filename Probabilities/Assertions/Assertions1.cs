namespace Probabilities
{
    public class Assertions1
    {
        public bool Assert()
        {
            var hand = new Hand();
            hand.AddCards(new[]
            {
                new Card(Suit.Spades, Kind.Three),
                new Card(Suit.Spades, Kind.Four),
                new Card(Suit.Spades, Kind.Five),
                new Card(Suit.Spades, Kind.Six),
                new Card(Suit.Spades, Kind.Seven),
                new Card(Suit.Diamonds, Kind.Eight),
                new Card(Suit.Spades, Kind.Nine),
            });

            return hand.Combination.Rank == CombinationName.StraightFlush 
                   && hand.Combination.Cards[0].Equals(new Card(Suit.Spades, Kind.Seven));
        }
    }
}
