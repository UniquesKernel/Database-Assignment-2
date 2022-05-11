using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class Society
    {
        [Key]
        public int SocietyId { get; set; }
        public int CVR { get; set; }
        public string? Name  { get; set; }
        public string? Activity { get; set; }
        public Person ApprovedMember { get; set; }
        public string Address { get; set; }
    }
}
