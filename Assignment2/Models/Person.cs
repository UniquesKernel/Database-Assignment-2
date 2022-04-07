using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class Person
    {   
        [Key]
        public long CPR { get; set; }
        public Society Society { get; set; }
    }
}
