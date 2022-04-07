using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class Person
    {   
        [Key]
        public long CPR { get; set; }
        public string Name { get; set; }
        public List<Society> Society { get; set; }

        public List<Society> Chairs { get; set; }  
    }
}
