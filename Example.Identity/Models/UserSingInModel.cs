using System.ComponentModel.DataAnnotations;

namespace Example.Identity.Models
{
    public class UserSingInModel
    {
        [Required(ErrorMessage ="Kullanıcı adı zorunlu")]
        public string UserName { get; set; } = String.Empty;
        [Required(ErrorMessage = "Şifre  zorunlu")]
        public string Password { get; set; } = String.Empty;
    }
}
