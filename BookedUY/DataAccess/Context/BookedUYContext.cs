using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public BookedUYContext() { }
        public BookedUYContext(DbContextOptions options) : base(options) { }
    }
}
