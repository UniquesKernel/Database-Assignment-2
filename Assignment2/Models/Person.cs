using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.Models
{
    public class Person
    {   
        [Key]
        public int PersonId { get; set; }
        public long CPR { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Society> Societies { get; set; }
        public List<Society> Chairs { get; set; }  
    }
}
