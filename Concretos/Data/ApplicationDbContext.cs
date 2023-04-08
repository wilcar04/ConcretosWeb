using Concretos.Models;
using Microsoft.EntityFrameworkCore;

namespace Concretos.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Study> Studies { get; set; }
        public DbSet<FabricationMethod> FabricationMethods { get; set; }
        public DbSet<Reactive> Reactives { get; set; }
        public DbSet<Ecuation> Ecuations { get; set; }

    }
}
