using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{

    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<User> User { get; set; }
    }
}
