using E_RandevuDomain.Entities;
using Microsoft.AspNetCore.Identity;

namespace E_Randevu;

public static class Helper
{
    public static async Task CreateUserAsync(WebApplication app)
    {
        using (var scoped = app.Services.CreateScope())
        {
            var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            if (!userManager.Users.Any())
            {
               await userManager.CreateAsync(new()
                {
                    FirstName = "Burhan",
                    LastName = "Canbolat",
                    Email = "admin@admin.com",
                    UserName = "admin",

                }, "1");


            }
        }

    }
}
