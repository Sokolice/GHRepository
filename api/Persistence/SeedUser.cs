using API.Domain;
using Microsoft.AspNetCore.Identity;

namespace API.Persistence
{
    public class SeedUser
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        DisplayName = "Admin", 
                        UserName="admin",
                        Email="admin@admin.cz"
                    }
                };

                foreach(var user in users)
                {
                   var result =  await userManager.CreateAsync(user, "Admin123");                
                }
        }
    }
}
