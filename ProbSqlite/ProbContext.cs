using Microsoft.EntityFrameworkCore;

namespace ProbSqlite
{
    public class ProbContext : DbContext
    {
        public DbSet<PairToPair> PairToPairs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=probabilities.db;");
        }
    }
}
