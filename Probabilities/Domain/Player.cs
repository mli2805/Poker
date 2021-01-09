namespace Probabilities
{
    public class Player
    {
        public string Name;
        public Hand Hand;

        public Player(string name, Hand hand)
        {
            Name = name;
            Hand = hand;
        }

        public int CompareTo(Player other)
        {
            return Hand.CompareTo(other.Hand);
        }
    }
}
