using EC_MicroServicesUser.Models;

namespace EC_MicroServicesProduct.Models
{
    public class Product
    {
        public int Id { get; set; }



        public string? Title { get; set; }



        public string? Description { get; set; }



        public double? Prix { get; set; }



        public User? Vendeur { get; set; }

    }
}