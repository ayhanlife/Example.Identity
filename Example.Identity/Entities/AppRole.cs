using Microsoft.AspNetCore.Identity;

namespace Example.Identity.Entities
{
    public class AppRole : IdentityRole<int>
    {
        public DateTime CretedTime { get; set; }
    }
}
