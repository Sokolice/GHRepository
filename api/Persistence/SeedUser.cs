using API.Domain;
using Microsoft.AspNetCore.Identity;

namespace API.Persistence
{
    public class SeedUser
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser{DisplayName = "Admin", UserName="admin"}
                };

                foreach(var user in users)
                {
                    await userManager.CreateAsync(user, "Admin123");
                }
            }
        }
    }
}
