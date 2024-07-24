using System.ComponentModel.DataAnnotations;

namespace Cars.API.Models
{
    public class Car
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; }
        
        [Required]
        public decimal Price { get; set; }
        
    }
}
