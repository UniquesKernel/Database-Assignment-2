using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class Room_Location
    {

        public int RoomNr { get; set; }
        public string Address { get; set;}
        public int MaxOccupants { get; set; }
        public HashSet<Property_Type>? Items { get; set; }
        public List<DayOfWeek> AvalibleDays { get; set; }
        public List<int> AvalibleHours { get; set; }
        public List<ReservationTime> ReservationTimes  { get; set;}         
    }
}
