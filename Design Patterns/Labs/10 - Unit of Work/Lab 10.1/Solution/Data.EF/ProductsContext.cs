using Microsoft.EntityFrameworkCore;

namespace Wincubate.UnitOfWorkExamples.Data.EF
{
    public class ProductsContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=90377;Trusted_Connection=True;");
        }
    }
}
