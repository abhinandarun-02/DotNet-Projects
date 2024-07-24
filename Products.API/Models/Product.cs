using System.ComponentModel.DataAnnotations;

namespace Products.API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string name { get; set; }
        public required string description { get; set; }
        public required double amount { get; set; }
    }

}
