using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;


namespace Example.Identity.Models
{
    public class UserCreateModel
    {

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Zorunlu alan")]
        public string UserName { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage="Zorunlu alan")]
        [System.ComponentModel.DataAnnotations.EmailAddress(ErrorMessage= "Email adresi istenen alan")]
        public string Email { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Zorunlu alan")]
        public string Password { get; set; }
        [System.ComponentModel.DataAnnotations.Compare("Password",ErrorMessage = "Zorunlu alan")]
        public string ConfirmPassword { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Zorunlu alan")]
        public string Gender { get; set; }
    }
}
