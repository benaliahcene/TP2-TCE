using TP2.Models

namespace Microservice_product.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public User? Job { get; set; }
    }
}
