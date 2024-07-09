using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Models;

namespace Dal
{
    public class CellarContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Cellar> Cellars { get; set; }
        public DbSet<Drawer> Drawers { get; set; }
        public DbSet<Bottle> Bottles { get; set; }

        public CellarContext(DbContextOptions options) : base(options)
        {
        }

        protected CellarContext()
        {
        }
    }
}
