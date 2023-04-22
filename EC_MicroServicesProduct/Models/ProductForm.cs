using EC_MicroServicesUser.Models;
using System.ComponentModel.DataAnnotations;

namespace EC_MicroServicesProduct.Models
{
    public class ProductForm
    {
        [Required(ErrorMessage = "ce champs obligatoire")]

        public int Id { get; set; }



        public string Title { get; set; }



        public string Description { get; set; }



        public double Prix { get; set; }



      

    }
}
