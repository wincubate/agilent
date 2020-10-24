using Microsoft.EntityFrameworkCore;

namespace Wincubate.MvvmPatternsExamples.Data.EF
{
    public class ParticipantsContext : DbContext
    {
        public DbSet<Participant> Participants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=90377;Trusted_Connection=True;");
        }
    }
}