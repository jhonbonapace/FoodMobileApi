using Domain.Entities;
using Domain.Entities.Location;
using Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace Infra.Repository
{

    public class DatabaseContext : DbContext
    {
        private readonly DatabaseSettings _databaseSettings;

        public DatabaseContext(DbContextOptions<DatabaseContext> options, IOptions<DatabaseSettings> databaseSettings) : base(options) {
            _databaseSettings = databaseSettings.Value;
        }
        public DbSet<User> User { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<City> City { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_databaseSettings.SqlDatabase, builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });

            base.OnConfiguring(optionsBuilder);
        }
    }
}
