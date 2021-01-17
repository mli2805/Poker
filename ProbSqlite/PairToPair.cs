namespace ProbSqlite
{
    public class PairToPair
    {
        public int Id{ get; set; }
        public string FirstPair{ get; set; }
        public string SecondPair{ get; set; }
        public int Win{ get; set; }
        public int Draw{ get; set; }
        public int Lose{ get; set; }

        public PairToPair(string firstPair, string secondPair, int win, int draw, int lose)
        {
            FirstPair = firstPair;
            SecondPair = secondPair;
            Win = win;
            Draw = draw;
            Lose = lose;
        }
    }

}
