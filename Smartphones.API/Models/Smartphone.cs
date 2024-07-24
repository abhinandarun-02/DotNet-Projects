using System.ComponentModel.DataAnnotations;

namespace Smartphones.API;

public class Smartphone
{
    public int Id { get; set; }

    [Required]
    [MinLength(3)]
    public string Name { get; set; }

    [Required]
    public string Features { get; set; }

    [Required]
    public DateTime LaunchDate { get; set; }

    [Required]
    [Range(500, double.MaxValue, ErrorMessage = "Price must be greater than 500")]
    public double Price { get; set; }

}
