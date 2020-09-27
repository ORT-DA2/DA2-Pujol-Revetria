using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataAccess.Context
{
    public class BookedUYContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookingStage> BookingStages { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<TouristicSpot> TouristicSpots { get; set; }
        public BookedUYContext() 
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>().HasKey(b => b.Id);
            modelBuilder.Entity<Booking>().Property(b => b.CheckIn).IsRequired();
            modelBuilder.Entity<Booking>().Property(b => b.CheckOut).IsRequired();
            modelBuilder.Entity<Booking>().Property(b => b.TotalPrice).IsRequired();
            modelBuilder.Entity<Booking>().HasOne<Accommodation>(b => b.Accommodation).WithMany(a => a.Bookings).HasForeignKey(b => b.AccommodationId);
            modelBuilder.Entity<Booking>().HasOne<Tourist>(b => b.HeadGuest).WithMany(t => t.Bookings).HasForeignKey(b => b.GuestId);

            modelBuilder.Entity<Guest>().HasKey(g => g.Id);
            modelBuilder.Entity<Guest>().Property(g => g.Multiplier);
            modelBuilder.Entity<Guest>().Property(g => g.Amount);
            modelBuilder.Entity<Guest>().HasOne<Booking>(b => b.Booking).WithMany(b => b.Guests).HasForeignKey(b=>b.BookingId);

            modelBuilder.Entity<BookingStage>().HasKey(s => s.Id);
            modelBuilder.Entity<BookingStage>().Property(b => b.EntryDate).IsRequired().HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<BookingStage>().Property(b => b.Description).IsRequired();
            modelBuilder.Entity<BookingStage>().Property(b => b.Status).IsRequired();
            modelBuilder.Entity<BookingStage>().HasOne<Booking>(s => s.AsociatedBooking).WithMany(b => b.BookingHistory).HasForeignKey(s => s.AsociatedBookingId);

            modelBuilder.Entity<Administrator>().HasKey(a => a.Id);
            modelBuilder.Entity<Administrator>().Property(a => a.Email);
            modelBuilder.Entity<Administrator>().Property(a => a.Password).IsRequired();
            modelBuilder.Entity<TouristicSpot>().HasKey(t => t.Id);
            modelBuilder.Entity<TouristicSpot>().Property(t => t.Name);
            modelBuilder.Entity<TouristicSpot>().HasOne<Region>(b => b.Region).WithMany(t => t.Spots).HasForeignKey(b => b.RegionId);

            modelBuilder.Entity<Accommodation>().HasKey(a => a.Id);
            modelBuilder.Entity<Accommodation>().Property(a => a.Full);
            modelBuilder.Entity<Accommodation>().Property(a => a.Name);
            modelBuilder.Entity<Accommodation>().Property(a => a.Address);
            modelBuilder.Entity<Accommodation>().Property(a => a.ContactNumber);
            modelBuilder.Entity<Accommodation>().Property(a => a.Information);
            modelBuilder.Entity<Accommodation>().Property(a => a.PricePerNight);
            modelBuilder.Entity<Accommodation>().HasOne<TouristicSpot>(a => a.Spot).WithMany(t => t.Accommodations).HasForeignKey(a => a.SpotId);

            modelBuilder.Entity<Tourist>().HasKey(t => t.Id);
            modelBuilder.Entity<Tourist>().Property(t => t.Email);
            modelBuilder.Entity<Tourist>().Property(t => t.Name);
            modelBuilder.Entity<Tourist>().Property(t => t.LastName);

            modelBuilder.Entity<Region>().HasKey(r => r.Id);
            modelBuilder.Entity<Region>().Property(t => t.Name);

            modelBuilder.Entity<Category>().HasKey(c => c.Id);
            modelBuilder.Entity<Category>().Property(t => t.Name);

            modelBuilder.Entity<BookingStage>().HasOne<Administrator>(a => a.Administrator).WithMany(b => b.Entries).HasForeignKey(s => s.AdministratorId);

            modelBuilder.Entity<CategoryTouristicSpot>().HasKey(t => new {t.CategoryId, t.TouristicSpotId});
            modelBuilder.Entity<CategoryTouristicSpot>().HasOne<Category>(ct => ct.Category).WithMany(c => c.Spots).HasForeignKey(ct => ct.CategoryId);
            modelBuilder.Entity<CategoryTouristicSpot>().HasOne<TouristicSpot>(ct => ct.TouristicSpot).WithMany(t => t.Categories).HasForeignKey(ct => ct.TouristicSpotId);
        }
        public BookedUYContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //if (!optionsBuilder.IsConfigured)
                //{
                //    string directory = Directory.GetCurrentDirectory();
                //    IConfigurationRoot configuration = new ConfigurationBuilder()
                //    .SetBasePath(directory)
                //    .AddJsonFile("appsettings.json")
                //    .Build();
                //    var connectionString = configuration.GetConnectionString(@"BookingUYDB");
                //    optionsBuilder.UseSqlServer(connectionString);
                //}
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database = BookedUYDB; Integrated Security = True;Trusted_Connection = True;MultipleActiveResultSets = True");
            }
        }


    }
}
