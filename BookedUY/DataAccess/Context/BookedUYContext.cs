﻿using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

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
        public DbSet<Tourist> Tourists { get; set; }
        public DbSet<AccommodationImage> AccommodationImages { get; set; }
        public DbSet<CategoryTouristicSpot> categoryTouristicSpots { get; set; }
        public DbSet<Review> Reviews { get; set; }

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
            modelBuilder.Entity<Booking>().HasOne(r => r.Rating).WithOne(b => b.Booking).HasForeignKey<Review>(b => b.BookingId);

            modelBuilder.Entity<Guest>().HasKey(g => g.Id);
            modelBuilder.Entity<Guest>().Property(g => g.Multiplier);
            modelBuilder.Entity<Guest>().Property(g => g.Amount);
            modelBuilder.Entity<Guest>().HasOne<Booking>(b => b.Booking).WithMany(b => b.Guests).HasForeignKey(b => b.BookingId);

            modelBuilder.Entity<BookingStage>().HasKey(s => s.Id);
            modelBuilder.Entity<BookingStage>().Property(b => b.EntryDate).IsRequired().HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<BookingStage>().Property(b => b.Description).IsRequired();
            modelBuilder.Entity<BookingStage>().Property(b => b.Status).IsRequired();
            modelBuilder.Entity<BookingStage>().HasOne<Booking>(s => s.AsociatedBooking).WithMany(b => b.BookingHistory).HasForeignKey(s => s.AsociatedBookingId);

            modelBuilder.Entity<Administrator>().HasKey(a => a.Id);
            modelBuilder.Entity<Administrator>().HasAlternateKey(a => a.Email);
            modelBuilder.Entity<Administrator>().Property(a => a.Password).IsRequired();

            modelBuilder.Entity<TouristicSpot>().HasKey(t => t.Id);
            modelBuilder.Entity<TouristicSpot>().HasAlternateKey(t => t.Name);
            modelBuilder.Entity<TouristicSpot>().HasOne<Region>(b => b.Region).WithMany(t => t.Spots).HasForeignKey(b => b.RegionId).IsRequired();
            modelBuilder.Entity<TouristicSpot>().Property(t => t.Image).IsRequired();

            modelBuilder.Entity<Accommodation>().HasKey(a => a.Id);
            modelBuilder.Entity<Accommodation>().Property(a => a.Full);
            modelBuilder.Entity<Accommodation>().HasAlternateKey(a => a.Name);
            modelBuilder.Entity<Accommodation>().Property(a => a.Address);
            modelBuilder.Entity<Accommodation>().Property(a => a.ContactNumber);
            modelBuilder.Entity<Accommodation>().Property(a => a.Information);
            modelBuilder.Entity<Accommodation>().Property(a => a.PricePerNight);
            modelBuilder.Entity<Accommodation>().HasOne<TouristicSpot>(a => a.Spot).WithMany(t => t.Accommodations).HasForeignKey(a => a.SpotId);

            modelBuilder.Entity<Tourist>().HasKey(t => t.Id);
            modelBuilder.Entity<Tourist>().HasAlternateKey(t => t.Email);
            modelBuilder.Entity<Tourist>().Property(t => t.Name);
            modelBuilder.Entity<Tourist>().Property(t => t.LastName);

            modelBuilder.Entity<Region>().HasKey(r => r.Id);
            modelBuilder.Entity<Region>().Property(t => t.Name);

            modelBuilder.Entity<Category>().HasKey(c => c.Id);
            modelBuilder.Entity<Category>().HasAlternateKey(t => t.Name);

            modelBuilder.Entity<BookingStage>().HasOne<Administrator>(a => a.Administrator).WithMany(b => b.Entries).HasForeignKey(s => s.AdministratorId);

            modelBuilder.Entity<AccommodationImage>().HasKey(i => i.Id);
            modelBuilder.Entity<AccommodationImage>().Property(i => i.Image);
            modelBuilder.Entity<AccommodationImage>().HasOne<Accommodation>(i => i.Accommodation).WithMany(a => a.Images).HasForeignKey(i => i.AccommodationId);

            modelBuilder.Entity<CategoryTouristicSpot>().HasKey(t => new { t.CategoryId, t.TouristicSpotId });
            modelBuilder.Entity<CategoryTouristicSpot>().HasOne<Category>(ct => ct.Category).WithMany(c => c.Spots).HasForeignKey(ct => ct.CategoryId);
            modelBuilder.Entity<CategoryTouristicSpot>().HasOne<TouristicSpot>(ct => ct.TouristicSpot).WithMany(t => t.Categories).HasForeignKey(ct => ct.TouristicSpotId);

            modelBuilder.Entity<Review>().HasKey(r=>r.Id);
            modelBuilder.Entity<Review>().Property(r => r.BookingId);
            modelBuilder.Entity<Review>().Property(r => r.Score);
            modelBuilder.Entity<Review>().Property(r => r.Comment);
            

        }

        public BookedUYContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    string directory = Directory.GetCurrentDirectory();
                    IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(directory)
                    .AddJsonFile("appsettings.json")
                    .Build();
                    var connectionString = configuration.GetConnectionString(@"BookedUYDB");
                    optionsBuilder.UseSqlServer(connectionString);
                }
                //optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database = BookedUYDB; Integrated Security = True;Trusted_Connection = True;MultipleActiveResultSets = True");
            }
        }
    }
}