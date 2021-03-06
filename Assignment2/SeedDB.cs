using Assignment2.Data;
using Assignment2.Models;

namespace Assignment2
{
    public class SeedDB
    {
        public static void Run(ApplicationDbContext context)
        {
            if(context.Reservations.Any())
            {
                return;
            }
            
            Person jens = new Person() { CPR = 10987654321, FirstName = "Jens", LastName = "Jensen" };

            Person hans = new Person() { CPR = 13123123211, FirstName = "Hans", LastName = "Hansen" };

            Society society = new Society() { Name = "Illuminati", Activity = "Plotting World Domination", CVR = 123456, Address = "Everywhere", Chairman = jens, Members = new List<Person>() { jens, hans } };

            Property_Type toilet = new Property_Type() { Item = "Toilet" };

            Room_Location location1 = new Room_Location()
            {
                Items = new HashSet<Property_Type>() { toilet },
                Address = "Nordborggade31A",
                MaxOccupants = 10,
                RoomNr = 1,
                AvailableTime = new List<DateTimeCostume>() {
                    new DateTimeCostume() { CosDateTime = new DateTime(2022,1,2,18,0,00)},
                    new DateTimeCostume() { CosDateTime = new DateTime(2022,1,2,19,0,00)}}
                
            };

            Reservation reservation = new Reservation()
            {
                StartTime = new DateTime(2022, 1, 2, 18, 0, 00),
                EndTime = new DateTime(2022, 1, 2, 19, 0, 00),
                BookingSociety = society,
                BookedRooms = location1,
                BookingMembers = jens

            };

            Municipality municipality = new Municipality()
            {
                Name = "Aarhus Kommune",
                Room_Locations = new List<Room_Location>() { location1 }
            };

            context.Add(reservation);

            context.Add(municipality);

            context.SaveChanges();
        }
    }
}
