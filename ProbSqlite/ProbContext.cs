using Microsoft.EntityFrameworkCore;

namespace ProbSqlite
{
    public class ProbContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<PairOfCards> Pairs { get; set; }
        public DbSet<Potential> Potentials { get; set; }
        public DbSet<PairToPairBattle> Battles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=probabilities.db;");
        }
    }
}
