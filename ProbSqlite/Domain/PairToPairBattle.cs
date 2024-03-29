﻿namespace ProbSqlite
{
    public class PairToPairBattle
    {
        public int Id { get; set; }
        public PairOfCards FirstPair { get; set; }
        public PairOfCards SecondPair { get; set; }
        public string Title { get; set; }
        public int Win { get; set; }
        public int Draw { get; set; }
        public int Lose { get; set; }

        public PairToPairBattle() {}
        public PairToPairBattle(PairOfCards firstPair, PairOfCards secondPair, int win, int draw, int lose)
        {
            FirstPair = firstPair;
            SecondPair = secondPair;
            Title = $"{firstPair} vs {secondPair}";
            Win = win;
            Draw = draw;
            Lose = lose;
        }
    }
}
