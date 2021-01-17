using ProbSqlite;

namespace ProbConsole
{
    class Program
    {
        static void Main()
        {
            using (var db = new ProbContext())
            {
                var item = new PairToPair("first", "second", 1, 2, 3);
                db.PairToPairs.Add(item);
                db.SaveChanges();
            }
        }
    }
}
