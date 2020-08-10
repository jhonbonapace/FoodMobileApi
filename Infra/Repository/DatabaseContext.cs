using Domain.Entities;
using Domain.Entities.Location;
using Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Infra.Repository
{

    public class DatabaseContext : DbContext
    {
        private readonly DatabaseSettings _databaseSettings;

        public DatabaseContext(DbContextOptions<DatabaseContext> options, IOptions<DatabaseSettings> databaseSettings) : base(options)
        {
            _databaseSettings = databaseSettings.Value;
        }
        public DbSet<User> User { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<City> City { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_databaseSettings.SqlDatabase, builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                builder.MigrationsAssembly("Api");
            });

            base.OnConfiguring(optionsBuilder);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    #region CountrySeed
        //    using (StreamReader r = new StreamReader("../app.Infra/Repository/DatabaseSeed/countries.json"))
        //    {
        //        string json = r.ReadToEnd();
        //        IEnumerable<Country> countries = JsonConvert.DeserializeObject<IEnumerable<Country>>(json);
        //        modelBuilder.Entity<Country>().HasData(countries);

        //    }
        //    #endregion
        //    #region StateSeed
        //    using (StreamReader r = new StreamReader("../app.Infra/Repository/DatabaseSeed/states.json"))
        //    {
        //        string json = r.ReadToEnd();
        //        IEnumerable<State> states = JsonConvert.DeserializeObject<IEnumerable<State>>(json);
        //        modelBuilder.Entity<State>().HasData(states);

        //    }

        //    #endregion
        //    #region CitySeed
        //    using (StreamReader r = new StreamReader("../app.Infra/Repository/DatabaseSeed/cities.json"))
        //    {
        //        string json = r.ReadToEnd();
        //        IEnumerable<City> cities = JsonConvert.DeserializeObject<IEnumerable<City>>(json);
        //        modelBuilder.Entity<City>().HasData(cities);

        //    }
        //    #endregion

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
