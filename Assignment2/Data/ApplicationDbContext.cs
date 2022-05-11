using System.ComponentModel;
using Assignment2.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
             => optionsBuilder.
            //LogTo(Console.WriteLine).
            UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BreakfasBuffet;Trusted_Connection=True;MultipleActiveResultSets=true");

        public DbSet<Municipality> Municipalities => Set<Municipality>();
        public DbSet<Person> People => Set<Person>();
        public DbSet<Property_Type> Property_Types => Set<Property_Type>();
        public DbSet<Room_Location> Room_Locations => Set<Room_Location>();
        public DbSet<Society> Societies => Set<Society>(); 
        public DbSet<Reservation> Reservations => Set<Reservation>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Person>()
              .HasMany(s => s.Societies)
              .WithMany(p => p.Members);

            modelBuilder.Entity<Person>()
                .HasIndex(p => p.CPR)
                .IsUnique(true);

            modelBuilder.Entity<Property_Type>()
                .HasIndex(p => p.Item)
                .IsUnique(true);

            modelBuilder.Entity<Society>()
              .HasOne(p => p.Chairman)
              .WithMany(b => b.Chairs)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Society>()
                .HasIndex(p => p.CVR)
                .IsUnique(true);

            modelBuilder.Entity<Room_Location>()
                .HasIndex(p => new {p.Address, p.RoomNr})
                .IsUnique(true);

            modelBuilder.Entity<Reservation>()
              .HasOne(b => b.BookedRooms)
              .WithMany(p => p.Reservations)
              .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
