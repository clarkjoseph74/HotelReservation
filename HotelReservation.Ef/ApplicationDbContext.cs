using HotelReservation.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Ef;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Guest>()
            .Property(guest => guest.FullName)
            .HasComputedColumnSql("[FirstName] + [LastName]");
        base.OnModelCreating(modelBuilder);
        
    }

    public DbSet<Room> Rooms { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Guest> Guests { get; set; }
    public DbSet<Review> Reviews { get; set; }
    
}