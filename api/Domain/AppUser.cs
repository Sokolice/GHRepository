using Microsoft.AspNetCore.Identity;

namespace API.Domain
{
    public class AppUser: IdentityUser
    {
        public string DisplayName {  get; set; }
        public string UserName {  get; set; }

        public string Email { get; set; }
        
    }
}
