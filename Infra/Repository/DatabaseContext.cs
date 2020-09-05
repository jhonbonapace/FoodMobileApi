using Domain.Entities;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_databaseSettings.SqlDatabase, builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                builder.MigrationsAssembly("Api");
                builder.CommandTimeout(240);
            });

            base.OnConfiguring(optionsBuilder);
        }

        // public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerFacilities> CustomerFacilities { get; set; }
        // public virtual DbSet<CustomerPaymentMethods> CustomerPaymentMethods { get; set; }
        // public virtual DbSet<CustomerProfilePictures> CustomerProfilePictures { get; set; }
        // public virtual DbSet<CustomerTags> CustomerTags { get; set; }
        // public virtual DbSet<CustomerWorkDays> CustomerWorkDays { get; set; }
        // public virtual DbSet<CustomerWorkDaysTimeOff> CustomerWorkDaysTimeOff { get; set; }
        public virtual DbSet<Facility> Facility { get; set; }
        public virtual DbSet<PaymentMethod> Paymentmethod { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<City> City { get; set; }
        // public virtual DbSet<Product> Product { get; set; }
        // public virtual DbSet<ProductCategory> ProductCategory { get; set; }

        // public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<User> User { get; set; }
        // public virtual DbSet<UserCommentaries> UserCommentaries { get; set; }
        public virtual DbSet<UserFavoriteCustomer> UserFavoriteCustomers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region CountrySeed
            using (StreamReader r = new StreamReader("../Infra/Repository/DatabaseSeed/countries.json"))
            {
                string json = r.ReadToEnd();
                IEnumerable<Country> countries = JsonConvert.DeserializeObject<IEnumerable<Country>>(json);
                modelBuilder.Entity<Country>().HasData(countries);

            }
            #endregion
            #region StateSeed
            using (StreamReader r = new StreamReader("../Infra/Repository/DatabaseSeed/states.json"))
            {
                string json = r.ReadToEnd();
                IEnumerable<State> states = JsonConvert.DeserializeObject<IEnumerable<State>>(json);
                modelBuilder.Entity<State>().HasData(states);

            }

            #endregion
            #region CitySeed
            using (StreamReader r = new StreamReader("../Infra/Repository/DatabaseSeed/cities.json"))
            {
                string json = r.ReadToEnd();
                IEnumerable<City> cities = JsonConvert.DeserializeObject<IEnumerable<City>>(json);
                modelBuilder.Entity<City>().HasData(cities);

            }
            #endregion
            #region PaymentMethodsSeed

            using (StreamReader r = new StreamReader("../Infra/Repository/DatabaseSeed/paymentMethods.json"))
            {
                string json = r.ReadToEnd();
                IEnumerable<PaymentMethod> Paymentmethod = JsonConvert.DeserializeObject<IEnumerable<PaymentMethod>>(json);
                modelBuilder.Entity<PaymentMethod>().HasData(Paymentmethod);

            }
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}