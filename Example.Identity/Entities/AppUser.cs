using Microsoft.AspNetCore.Identity;

namespace Example.Identity.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string? ImagePath { get; set; } = String.Empty;
        public string? Gender { get; set; } = String.Empty;
    }
}
