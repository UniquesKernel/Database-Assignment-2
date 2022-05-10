using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Assignment2.Models
{
    public class Person
    {   
        [Key]
        public long CPR { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Society> Society { get; set; }
        [NotMapped]
        public List<Reservation> Reservations { get; set; }
        public List<Society> Chairs { get; set; }  
    }
}
