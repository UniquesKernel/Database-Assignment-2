using Microsoft.EntityFrameworkCore;

namespace Assignment2.Data
{
    public class TestQueries
    {

        public void QueryMunicipality(ApplicationDbContext context)
        {

            var roomAddresses = context.Room_Locations.ToList();
            Console.WriteLine($"Municipality Query for all room addresses:");
            Console.WriteLine($"{"Room Addresses",-25}");
            foreach (var address in roomAddresses)
            {
                Console.WriteLine($"{address.Address,-25}");
            }
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void QuerySocieties(string queryString, ApplicationDbContext context)
        {
            var societies = context.Societies.Include(c => c.Chairman).Where(s => s.Activity.ToLower() == queryString.ToLower());
            Console.WriteLine("Query for Societies by activity");
            Console.WriteLine("{0,-25}{1,-15}{2,-15}{3,-15}", "Activity", "CVR", "Chairman", "Address");
            foreach (var s in societies)
            {
                Console.WriteLine($"{s.Activity,-25}{s.CVR,-15}{s.Chairman.FirstName + " " + s.Chairman.LastName,-15}{s.Address,-15}");
            }
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void QueryBookedRooms(ApplicationDbContext context)
        {
            var Reservation = context.Reservations.Include(b => b.BookedRooms).Include(c => c.BookingSociety.Chairman).Include(s => s.BookingSociety).ToList();

            Console.WriteLine($"Query for booked Rooms");
            Console.WriteLine($"{"Booked Room Nr",-20}{"Booked Room Address",-25}{"Booking Society Name",-25}{"Booking Society Chairman",-25}{"Booking Chairman CPR",-25}{"StartTime",-25}{"EndTime",-25}");
            foreach (var resevation in Reservation)
            {
                Console.WriteLine($"{resevation.BookedRooms.RoomNr,-20}{resevation.BookedRooms.Address,-25}{resevation.BookingSociety.Name,-25}{resevation.BookingSociety.Chairman.FirstName + " " + resevation.BookingSociety.Chairman.LastName,-25}{resevation.BookingSociety.Chairman.CPR,-25}{resevation.StartTime,-25}{resevation.EndTime,-2515}");
            }
            Console.WriteLine("");
            Console.WriteLine("");
        }
    }
}
