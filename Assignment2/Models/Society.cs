using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class Society
    {
        [Key]
        public int CVR { get; set; }
        public string? Name  { get; set; }
        public string? Activity { get; set; }
        public List<Person>? Members { get; set; }
        public Person Chairman { get; set; }

    }
}
