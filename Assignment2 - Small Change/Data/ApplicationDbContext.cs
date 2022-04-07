using System.ComponentModel;
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
        public DbSet<Reservation> Reservations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room_Location>()
                .HasKey(c => new { c.RoomNr, c.Address });
            modelBuilder.Entity<Society>()
                .HasOne(p => p.ApprovedMember)
                .WithMany(b => b.Society);
            modelBuilder.Entity<Reservation>()
              .HasOne(b => b.BookedRooms)
              .WithMany(p => p.Reservations);
            modelBuilder.Entity<DateTimeCostume>()
              .HasKey(time => time.CosDateTime);
        }

        public void QueryMunicipality()
        {
          var roomAddresses = Room_Locations.ToList();
          Console.WriteLine($"Municipality Query for all room addresses:");
          Console.WriteLine($"{"Room Addresses", -25}");
          foreach (var address in roomAddresses)
          {
            Console.WriteLine($"{address.Address,-25}");
          }
          Console.WriteLine("");
          Console.WriteLine("");
        }

        public void QuerySocieties(string queryString)
        {
          var societies = Societies.Where(s => s.Activity.ToLower() == queryString.ToLower());
          Console.WriteLine("Query for Societies by activity");
          Console.WriteLine("{0,-25}{1,-15}{2,-15}{3,-15}", "Activity", "CVR", "Chairman", "Address");
          foreach (var s in societies)
          {
            Console.WriteLine($"{s.Activity,-25}{s.CVR,-15}{s.ApprovedMember.Name,-15}{s.Address,-15}");
          }
          Console.WriteLine("");
          Console.WriteLine("");
        }

        public void QueryBookedRooms()
        {
          var Reservation = Reservations.ToList();
          
          Console.WriteLine($"Query for booked Rooms");
          Console.WriteLine($"{"Booked Room Nr", -20}{"Booked Room Address",-25}{"Booking Society Name",-25}{"Booking Society Chairman", -25}{"Booking Chairman CPR",-25}{"StartTime",-25}{"EndTime",-25}");
          foreach (var resevation in Reservation)
          {
            Console.WriteLine($"{resevation.BookedRooms.RoomNr,-20}{resevation.BookedRooms.Address, -25}{resevation.BookingSociety.Name,-25}{resevation.BookingSociety.ApprovedMember.Name,-25}{resevation.BookingSociety.ApprovedMember.CPR,-25}{resevation.StartTime,-25}{resevation.EndTime,-2515}");
          }
          Console.WriteLine("");
          Console.WriteLine("");
        }

        public void QueryFutureBookings(long keyPerson, DateTime dateTime)
        {
          var Res= Reservations.Where(r => r.BookingMembers.CPR == keyPerson && r.StartTime >= dateTime).ToList();
          Console.WriteLine($"Query for FutureBookings");
          Console.WriteLine($"{"Booked Room Nr", -20}{"Booked Room Address",-25}{"Booking Society Name",-25}{"StartTime",-25}{"EndTime",-25}{"Access Method",-25}");
          foreach (var resevation in Res)
          {
            Console.WriteLine($"{resevation.BookedRooms.RoomNr,-20}{resevation.BookedRooms.Address, -25}{resevation.BookingSociety.Name,-25}{resevation.StartTime,-25}{resevation.EndTime,-2515}{resevation.BookedRooms.AccessMethod,-25}");
          }
          Console.WriteLine("");
          Console.WriteLine("");
        }

        public void SeedDatabase()
        {
          var availTime = new DateTimeCostume() { CosDateTime = new DateTime(2020,9,1)};
          var item = new Property_Type(){Item = "Toilet"};
          var room = new Room_Location()
          {
            RoomNr = 1,
            Address = "New York",
            AvailableTime = new List<DateTimeCostume>(){availTime},
            Items = new HashSet<Property_Type>(){item},
            MaxOccupants = 1,
            Reservations = new List<Reservation>(),
            AccessMethod = "Access Code"
          };

          var person = new Person()
          {
            CPR = 123456789,
            Name = "Hans Hansen",
            Society = new List<Society>(),
            HomeAddress = "New York",
            PassPortNr = 123,
            PhoneNr = 987654321
          };

          var soc = new Society()
          {
            Activity = "Paintball",
            Address = "New York Street",
            ApprovedMember = null,
            CVR = 123456,
            Name = "New York Paintball Club"
          };

          var Res = new Reservation()
          {
            BookedRooms = room,
            BookingSociety = soc,
            BookingMembers = person,
            StartTime = new DateTime(2022,9,1,12,0,0),
            EndTime = new DateTime(2022,9,1,14,0,0)
          };

          soc.ApprovedMember = person;

          Reservations.Add(Res);
          People.Add(person);
          Societies.Add(soc);
          Property_Types.Add(item);


          SaveChanges();
        }
    }
}
