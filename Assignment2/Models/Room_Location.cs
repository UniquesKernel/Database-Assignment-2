using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class Room_Location
    {
        [Key]
        public int Room_LocationId { get; set; }
        public int RoomNr { get; set; }
        public string Address { get; set;}
        public int MaxOccupants { get; set; }
        public HashSet<Property_Type>? Items { get; set; }
        public List<Reservation> Reservations { get; set; }
        public List<DateTimeCostume> AvailableTime { get; set; }
    }
}
