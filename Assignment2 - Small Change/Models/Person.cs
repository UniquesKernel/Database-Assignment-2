using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class Person
    {   
        [Key]
        public long CPR { get; set; }
        public string Name { get; set; }
        public string HomeAddress { get; set; }
        public long PhoneNr { get; set; }
        public int PassPortNr { get; set; }
        public List<Society> Society { get; set; }
    }
}
