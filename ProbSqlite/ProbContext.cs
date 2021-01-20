using Microsoft.EntityFrameworkCore;

namespace ProbSqlite
{
    /*
     * Для изменения если не работает из Package Manager Console
     * запустить из командной строки в каталоге солюшена
     * dotnet ef migrations add здесь_название_миграции --project ProbSqlite --startup-project ProbConsole
     * dotnet ef database update --project ProbSqlite --startup-project ProbConsole
     */

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
