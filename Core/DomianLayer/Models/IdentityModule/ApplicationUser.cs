using Microsoft.AspNetCore.Identity;

namespace DomianLayer.Models.IdentityModule
{
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; } = default!;
        public Address? Address { get; set; }
    }
}