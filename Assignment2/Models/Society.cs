using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment2.Models
{
    public class Society
    {
        [Key]
        public int SocietyId { get; set; }
        public int CVR { get; set; }
        public string Name  { get; set; }
        public string Activity { get; set; }
        public Person Chairman { get; set; }
        public string Address { get; set; }
        public List<Person> Members { get; set; }
    }
}
