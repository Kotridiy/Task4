using DataModel;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class ApplicationContext : DbContext
    {
        public DbSet<IClient> Clients { get; set; }
        public DbSet<IManager> Managers { get; set; }
        public DbSet<IProduct> Products { get; set; }
        public DbSet<ISoldProduct> SoldProducts { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        }
    }
}