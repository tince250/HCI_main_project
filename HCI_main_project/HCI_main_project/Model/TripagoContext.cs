using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HCI_main_project.Models;

public partial class TripagoContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Tour> Tours { get; set; }
    public DbSet<Attraction> Attractions { get; set; }
    public DbSet<Accommodation> Accommodations { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<TourAccommodation> TourAccommodations { get; set; }
    public DbSet<TourAttraction> TourAttractions { get; set; }
    public DbSet<TourRestaurant> TourRestaurants { get; set; }
    public DbSet<TourTraveler> TourTravelers { get; set; }

    public TripagoContext(DbContextOptions<TripagoContext> options)
            : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TourAccommodation>()
              .HasKey(x => new { x.TourId, x.AccommodationId});
        modelBuilder.Entity<TourAttraction>()
              .HasKey(x => new { x.TourId, x.AttractionId});
        modelBuilder.Entity<TourRestaurant>()
              .HasKey(x => new { x.TourId, x.RestaurantId});
        modelBuilder.Entity<TourTraveler>()
              .HasKey(x => new { x.TourId, x.TravelerId});
    }

}
