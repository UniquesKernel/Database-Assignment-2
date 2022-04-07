using Assignment2.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseInMemoryDatabase("Assigment2DB");

        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Property_Type> Property_Types { get; set; }
        public DbSet<Room_Location> Room_Locations { get; set; }
        public DbSet<Society> Societies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room_Location>()
                .HasKey(c => new { c.RoomNr, c.Address });
        }
    }
}
