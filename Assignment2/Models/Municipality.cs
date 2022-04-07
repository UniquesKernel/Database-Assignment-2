using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class Municipality
    {
        [Key]
        public string Name { get; set; }
        public List<Room_Location> Room_Locations { get; set; }
    }
}
