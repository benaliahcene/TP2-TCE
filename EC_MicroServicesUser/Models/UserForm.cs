using System.ComponentModel.DataAnnotations;

namespace EC_MicroServicesUser.Models

{
    public class UserForm
    {
        [Required(ErrorMessage = "ce champs obligatoire")]
        public string? LastName { get; set; }



        public string? FirstName { get; set; }



        public string? Fonction { get; set; }

    }
}
