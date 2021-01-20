using System;
using System.Collections.Generic;
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

            // var startPoint = int.Parse(args[0]);
            // RunBattles(startPoint);

            // BattlesToDb();

            // SumBattlesUp();

            Console.WriteLine("Done.");
            Console.ReadLine();
        }

        private static void BattlesToDb()
        {
            var content = File.ReadAllLines(@"C:\Users\mli2805\source\repos\Poker\ProbConsole\txt\prob001-168.txt");

            using var db = new ProbContext();
            Deck.Load(db);
            var battles = content.Select(s => FromString(s, db)).ToList();
            var res = CheckBattles(db, battles);
            // if (!res) return;
            db.Battles.AddRange(battles);
            db.SaveChanges();
        }

        private static void SumBattlesUp(ProbContext db, List<PairToPairBattle> battles)
        {
            var potentials = db.Potentials.ToList();
            foreach (var potential in potentials)
            {
                var pair = db.Pairs.First(p => p.Potential.Id == potential.Id);
                var battlesAsHost = battles.Where(b => b.FirstPair.Id == pair.Id);
                foreach (var battle in battlesAsHost)
                {
                    potential.Win += battle.Win;
                    potential.Draw += battle.Draw;
                    potential.Lose += battle.Lose;
                }

                var battlesAsGuest = battles.Where(b => b.SecondPair.Id == pair.Id);
                foreach (var battle in battlesAsGuest)
                {
                    potential.Win += battle.Lose;
                    potential.Draw += battle.Draw;
                    potential.Lose += battle.Win;
                }
            }
        }

        private static PairToPairBattle FromString(string str, ProbContext db)
        {
            var ss = str.Split(' ');
            var firstPairId = int.Parse(ss[3]);
            var secondPairId = int.Parse(ss[5]);
            var wins = int.Parse(ss[7]);
            var draws = int.Parse(ss[9]);
            var loses = int.Parse(ss[11]);

            var firstPair = db.Pairs.First(p => p.Id == firstPairId);
            var secondPair = db.Pairs.First(p => p.Id == secondPairId);

            return new PairToPairBattle(firstPair, secondPair, wins, draws, loses);
        }

        private static bool CheckBattles(ProbContext db, List<PairToPairBattle> battles)
        {
            var streamWriterOk = File.CreateText($@"c:\tmp\probCheckOk.txt");
            var streamWriterError = File.CreateText($@"c:\tmp\probCheckError.txt");
            var flag = true;
            for (int i = 1; i <= 168; i++)
            {
                for (int j = i + 1; j <= 169; j++)
                {
                    var pair1 = db.Pairs.First(p => p.Potential.Id == i);
                    var pair2 = db.Pairs.First(p => p.Potential.Id == j);

                    var battle = battles.FirstOrDefault(b => b.FirstPair.Equals(pair1) && b.SecondPair.Equals(pair2));
                    string line;
                    if (battle == null)
                    {
                        flag = false;
                        line = $"{DateTime.Now} (i={i:000}) - (j={j:000})";
                        streamWriterError.WriteLine(line);
                        streamWriterError.Flush();
                    }
                    else
                    {
                        line = $"{DateTime.Now} (i={i:000}) - (j={j:000}) {battle.FirstPair.Id} - {battle.SecondPair.Id} : {battle.Win} - {battle.Draw} - {battle.Lose}";
                        streamWriterOk.WriteLine(line);
                        streamWriterOk.Flush();
                    }

                }
                Console.WriteLine($"{DateTime.Now} (i={i:000})");
            }

            return flag;
        }


        private static void RunBattles(int startPoint)
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
