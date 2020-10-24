using Microsoft.EntityFrameworkCore;
using System;

namespace Wincubate.RepositoryExamples.Data.EF
{
    public class ProductsContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=90377;Trusted_Connection=True;");
        }
    }
}
