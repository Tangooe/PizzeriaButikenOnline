using Microsoft.AspNetCore.Identity;
using PizzeriaButikenOnline.Models;

namespace PizzeriaButikenOnline.Data
{
    public static class DbInitializer
    {
        public static void Initialize(UserManager<ApplicationUser> userManager)
        {
            var user = new ApplicationUser
            {
                UserName = "Tangooe@user.com",
                Email = "Tangooe@user.com"
            };

            userManager.CreateAsync(user, "Abc!23");
        }
    }
}
