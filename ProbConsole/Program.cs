using Logic;
using ProbSqlite;

namespace ProbConsole
{
    class Program
    {
        static void Main()
        {
            SeedCards();
            SeedPairs();
        }

        private static void SeedPairs()
        {
            using var db = new ProbContext();
            Deck.Load(db);
            var listOfLists = EquipotentPairs.Get();
            foreach (var list in listOfLists)
            {
                var potential = new Potential();
                db.Potentials.Add(potential);
                foreach (var pairOfCard in list)
                {
                    pairOfCard.Potential = potential;
                    db.Pairs.Add(pairOfCard);
                }
            }
            db.SaveChanges();
        }

        private static void SeedCards()
        {
            using var db = new ProbContext();
            db.Cards.AddRange(Deck.CardsInOrder);
            db.SaveChanges();
        }
    }
}
