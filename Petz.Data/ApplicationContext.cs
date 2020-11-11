using Microsoft.EntityFrameworkCore;
using Petz.Business.Models;

namespace Petz.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;");
        }
    }
}
