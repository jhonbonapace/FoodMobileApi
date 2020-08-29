using System;
using System.Collections.Generic;
using System.IO;
using Domain.Entities;
using Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

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
            optionsBuilder.UseMySql(_databaseSettings.SqlDatabase, builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                builder.MigrationsAssembly("Api");
                builder.CommandTimeout(240);
            });

            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Customerfacilities> Customerfacilities { get; set; }
        public virtual DbSet<Customerpaymentmethods> Customerpaymentmethods { get; set; }
        public virtual DbSet<Customerprofilepictures> Customerprofilepictures { get; set; }
        public virtual DbSet<Customertags> Customertags { get; set; }
        public virtual DbSet<Customerworkdays> Customerworkdays { get; set; }
        public virtual DbSet<Customerworkdaystimeoff> Customerworkdaystimeoff { get; set; }
        public virtual DbSet<Facility> Facility { get; set; }
        public virtual DbSet<Paymentmethod> Paymentmethod { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Productcategory> Productcategory { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Usercommentaries> Usercommentaries { get; set; }
        public virtual DbSet<Userfavoritecustomers> Userfavoritecustomers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region DatabaseModel
            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.Property(e => e.Bacen)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Initials)
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NamePt)
                    .HasColumnName("Name_PT")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("state");

                entity.HasIndex(e => e.IdCountry)
                    .HasName("IdCountry");

                entity.Property(e => e.Ibgecode)
                    .HasColumnName("IBGECode")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Initials)
                    .HasColumnType("char(2)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NumberCode)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdCountryNavigation)
                    .WithMany(p => p.State)
                    .HasForeignKey(d => d.IdCountry)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("state_ibfk_1");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.HasIndex(e => e.IdState)
                    .HasName("IdState");

                entity.Property(e => e.Ibgecode)
                    .HasColumnName("IBGECode")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdStateNavigation)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.IdState)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("city_ibfk_1");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("address");

                entity.HasIndex(e => e.IdCity)
                    .HasName("IdCity");

                entity.HasIndex(e => e.IdCountry)
                    .HasName("IdCountry");

                entity.HasIndex(e => e.IdState)
                    .HasName("IdState");

                entity.Property(e => e.Complement)
                    .HasColumnType("varchar(250)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.District)
                    .HasColumnType("varchar(250)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Number)
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Street)
                    .HasColumnType("varchar(250)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ZipCode)
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdCityNavigation)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.IdCity)
                    .HasConstraintName("address_ibfk_3");

                entity.HasOne(d => d.IdCountryNavigation)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.IdCountry)
                    .HasConstraintName("address_ibfk_1");

                entity.HasOne(d => d.IdStateNavigation)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.IdState)
                    .HasConstraintName("address_ibfk_2");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("booking");

                entity.HasIndex(e => e.IdComment)
                    .HasName("IdComment");

                entity.HasIndex(e => e.IdCustomer)
                    .HasName("IdCustomer");

                entity.HasIndex(e => e.IdUser)
                    .HasName("IdUser");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Deleted)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.GuestQuantity).HasDefaultValueSql("'1'");

                entity.Property(e => e.Request)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ReservationCode)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdCommentNavigation)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.IdComment)
                    .HasConstraintName("booking_ibfk_3");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("booking_ibfk_1");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("booking_ibfk_2");
            });

            modelBuilder.Entity<Contacts>(entity =>
            {
                entity.ToTable("contacts");

                entity.HasIndex(e => e.IdCustomer)
                    .HasName("IdCustomer");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(500)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("contacts_ibfk_1");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.HasIndex(e => e.IdAddress)
                    .HasName("IdAddress");

                entity.HasIndex(e => e.IdNacionalitySpecialty)
                    .HasName("IdNacionalitySpecialty");

                entity.HasIndex(e => e.IdUser)
                    .HasName("IdUser");

                entity.Property(e => e.BookingNote)
                    .HasColumnType("varchar(300)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.LastUpdate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(250)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Specialty)
                    .HasColumnType("varchar(300)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Thumbnail).HasColumnType("blob");

                entity.HasOne(d => d.IdAddressNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.IdAddress)
                    .HasConstraintName("customer_ibfk_2");

                entity.HasOne(d => d.IdNacionalitySpecialtyNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.IdNacionalitySpecialty)
                    .HasConstraintName("customer_ibfk_3");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customer_ibfk_1");
            });

            modelBuilder.Entity<Customerfacilities>(entity =>
            {
                entity.ToTable("customerfacilities");

                entity.HasIndex(e => e.IdCustomer)
                    .HasName("IdCustomer");

                entity.HasIndex(e => e.IdFacility)
                    .HasName("IdFacility");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.IsActive)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Customerfacilities)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customerfacilities_ibfk_2");

                entity.HasOne(d => d.IdFacilityNavigation)
                    .WithMany(p => p.Customerfacilities)
                    .HasForeignKey(d => d.IdFacility)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customerfacilities_ibfk_1");
            });

            modelBuilder.Entity<Customerpaymentmethods>(entity =>
            {
                entity.ToTable("customerpaymentmethods");

                entity.HasIndex(e => e.IdCustomer)
                    .HasName("IdCustomer");

                entity.HasIndex(e => e.IdPaymentMethod)
                    .HasName("IdPaymentMethod");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Customerpaymentmethods)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customerpaymentmethods_ibfk_2");

                entity.HasOne(d => d.IdPaymentMethodNavigation)
                    .WithMany(p => p.Customerpaymentmethods)
                    .HasForeignKey(d => d.IdPaymentMethod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customerpaymentmethods_ibfk_1");
            });

            modelBuilder.Entity<Customerprofilepictures>(entity =>
            {
                entity.ToTable("customerprofilepictures");

                entity.HasIndex(e => e.IdCustomer)
                    .HasName("IdCustomer");

                entity.Property(e => e.ImagePath)
                    .IsRequired()
                    .HasColumnType("varchar(500)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Size).HasColumnType("decimal(10,0)");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Customerprofilepictures)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customerprofilepictures_ibfk_1");
            });

            modelBuilder.Entity<Customertags>(entity =>
            {
                entity.ToTable("customertags");

                entity.HasIndex(e => e.IdCustomer)
                    .HasName("IdCustomer");

                entity.HasIndex(e => e.IdTag)
                    .HasName("IdTag");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Customertags)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customertags_ibfk_2");

                entity.HasOne(d => d.IdTagNavigation)
                    .WithMany(p => p.Customertags)
                    .HasForeignKey(d => d.IdTag)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customertags_ibfk_1");
            });

            modelBuilder.Entity<Customerworkdays>(entity =>
            {
                entity.ToTable("customerworkdays");

                entity.HasIndex(e => e.IdCustomer)
                    .HasName("IdCustomer");

                entity.Property(e => e.TimeClose).HasColumnType("timestamp");

                entity.Property(e => e.TimeOpen).HasColumnType("timestamp");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Customerworkdays)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customerworkdays_ibfk_1");
            });

            modelBuilder.Entity<Customerworkdaystimeoff>(entity =>
            {
                entity.ToTable("customerworkdaystimeoff");

                entity.HasIndex(e => e.IdCustomerWorkDays)
                    .HasName("IdCustomerWorkDays");

                entity.Property(e => e.TimeEnd).HasColumnType("timestamp");

                entity.Property(e => e.TimeStart).HasColumnType("timestamp");

                entity.HasOne(d => d.IdCustomerWorkDaysNavigation)
                    .WithMany(p => p.Customerworkdaystimeoff)
                    .HasForeignKey(d => d.IdCustomerWorkDays)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customerworkdaystimeoff_ibfk_1");
            });

            modelBuilder.Entity<Facility>(entity =>
            {
                entity.ToTable("facility");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Paymentmethod>(entity =>
            {
                entity.ToTable("paymentmethod");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.HasIndex(e => e.IdProductCategory)
                    .HasName("IdProductCategory");

                entity.Property(e => e.Deleted)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(500)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ImagePath)
                    .HasColumnType("varchar(500)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.IsPriceless).HasColumnType("bit(1)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Price).HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.IdProductCategoryNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.IdProductCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_ibfk_1");
            });

            modelBuilder.Entity<Productcategory>(entity =>
            {
                entity.ToTable("productcategory");

                entity.HasIndex(e => e.IdCustomer)
                    .HasName("IdCustomer");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(500)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.IsExcluded)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Productcategory)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("productcategory_ibfk_1");
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.ToTable("tags");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Deleted)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Gender)
                .HasConversion<int>();

                entity.Property(e => e.UserType)
                .IsRequired()
                .HasConversion<int>();

                entity.Property(e => e.Identity)
                    .HasColumnType("varchar(14)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Ip)
                    .HasColumnName("IP")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(250)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Thumbnail).HasColumnType("blob");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Usercommentaries>(entity =>
            {
                entity.ToTable("usercommentaries");

                entity.HasIndex(e => e.IdCustomer)
                    .HasName("IdCustomer");

                entity.HasIndex(e => e.IdUser)
                    .HasName("IdUser");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Rating).HasColumnType("decimal(10,2)");

                entity.Property(e => e.Text)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Usercommentaries)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usercommentaries_ibfk_1");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Usercommentaries)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usercommentaries_ibfk_2");
            });

            modelBuilder.Entity<Userfavoritecustomers>(entity =>
            {
                entity.ToTable("userfavoritecustomers");

                entity.HasIndex(e => e.IdCustomer)
                    .HasName("IdCustomer");

                entity.HasIndex(e => e.IdUser)
                    .HasName("IdUser");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Userfavoritecustomers)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("userfavoritecustomers_ibfk_1");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Userfavoritecustomers)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("userfavoritecustomers_ibfk_2");
            });
            #endregion
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
                IEnumerable<Paymentmethod> Paymentmethod = JsonConvert.DeserializeObject<IEnumerable<Paymentmethod>>(json);
                modelBuilder.Entity<Paymentmethod>().HasData(Paymentmethod);

            }
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}