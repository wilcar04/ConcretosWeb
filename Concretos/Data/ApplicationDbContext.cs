using Concretos.Models;
using Microsoft.EntityFrameworkCore;

namespace Concretos.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Study> Studies { get; set; }
    }
}
