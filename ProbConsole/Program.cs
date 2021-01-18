using System;
using System.IO;
using System.Linq;
using Logic;
using ProbSqlite;

namespace ProbConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // SeedCards();
            // SeedPairs();

            var startPoint = int.Parse(args[0]);

            EvaluatePotentials(startPoint);
            Console.ReadLine();
        }

        private static void EvaluatePotentials(int startPoint)
        {
            Console.WriteLine($"{DateTime.Now} Started from {startPoint}.");
            var streamWriter = File.CreateText($@"c:\tmp\prob{startPoint}.txt");
            using var db = new ProbContext();
            Deck.Load(db);
            var endPoint = startPoint + 50;
            if (endPoint > 168) endPoint = 168;
            for (int i = startPoint; i <= endPoint; i++)
            {
                for (int j = i + 1; j <= 169; j++)
                {
                    var pair1 = db.Pairs.First(p => p.Potential.Id == i);
                    var pair2 = db.Pairs.First(p => p.Potential.Id == j);

                    var battle = pair1.Compare(pair2);
                    db.Battles.Add(battle);
                    var line = $"{DateTime.Now} (i={i}) {battle.FirstPair.Id} - {battle.SecondPair.Id} : {battle.Win} - {battle.Draw} - {battle.Lose}";
                    Console.WriteLine(line);
                    streamWriter.WriteLine(line);
                    streamWriter.Flush();
                }
            }

            db.SaveChanges();
            Console.WriteLine($"{DateTime.Now} Done.");
            streamWriter.Close();
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
