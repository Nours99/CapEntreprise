using Microsoft.EntityFrameworkCore;
using Models;

namespace Dal
{
    public class CellarContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Cellar> Cellars { get; set; }
        public DbSet<Drawer> Drawers { get; set; }
        public DbSet<Bottle> Bottle { get; set; }

        public CellarContext(DbContextOptions<CellarContext> options) : base(options)
        {
        }

        public CellarContext() :base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=WineCellarDB;Trusted_Connection=True");
            }
        }
    }
}
