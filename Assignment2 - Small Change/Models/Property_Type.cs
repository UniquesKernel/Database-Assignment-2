using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class Property_Type
    {    
        [Key]
        public int Property_TypeId { get; set; }
        public string Item { get; set; }
    }
}
