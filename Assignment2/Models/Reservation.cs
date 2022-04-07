using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.Models
{
    public class Reservation
    { 
      [Key]
      public int Id { get; set; }
      public Room_Location BookedRooms { get; set; }
      public Person BookingMembers { get; set; }
      public Society BookingSociety { get; set; } 
      public DateTime StartTime { get; set; }
      public DateTime EndTime { get; set; }
        
    }
}
