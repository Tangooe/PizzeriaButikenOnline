using Microsoft.AspNetCore.Identity;
using PizzeriaButikenOnline.Entities;
using PizzeriaButikenOnline.Models;
using System.Collections.Generic;
using System.Linq;

namespace PizzeriaButikenOnline.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if(!context.Ingredients.Any())
            {
                var categories = new List<Category>
                {
                    new Category { Name = "Italienska Pizzor" },
                    new Category { Name = "Kebab Pizzor" },
                    new Category { Name = "Sallader" },
                    new Category { Name = "Drycker" }
                };

                var ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Skinka" },
                    new Ingredient { Name = "Champinjoner" },
                    new Ingredient { Name = "Annanass" },
                    new Ingredient { Name = "Färska Tomater" },
                    new Ingredient { Name = "Kebab" },
                    new Ingredient { Name = "Isbergssallad" },
                    new Ingredient { Name = "Vitlökssås" },
                    new Ingredient { Name = "Kebabsås" }
                };

                context.Ingredients.AddRange(ingredients);
                context.SaveChanges();

                context.Dishes.AddRange(new List<Dish>
                {
                    new Dish
                    {
                        Name = "Capprisiosa",
                        Description = "Klassisk Italiensk Pizza",
                        Category = categories.First(x => x.Name =="Italienska Pizzor"),
                        Price = 80,             
                        Igredients = ingredients.Where(x => 
                            x.Name == "Skinka" || 
                            x.Name == "Champinjoner")
                            .ToList()
                    },
                    new Dish
                    {
                        Name = "Hawaii",
                        Description = "Klassisk Italiensk Pizza",
                        Price = 80,
                        Category = categories.First(x => x.Name =="Italienska Pizzor"),
                        Igredients = ingredients.Where(x => 
                            x.Name == "Skinka" || 
                            x.Name == "Annanass")
                            .ToList()
                    },
                    new Dish
                    {
                        Name = "Kebab Pizza",
                        Description = "Kebab Pizza",
                        Price = 85,
                        Category = categories.First(x => x.Name == "Kebab Pizzor"),
                        Igredients = ingredients.Where(x => 
                            x.Name == "Kebab" ||
                            x.Name == "Kebabsås")
                            .ToList()
                    }
                });
                context.SaveChanges();
            }

            if(!context.Users.Any())
            {
                var adminRole = new IdentityRole { Name = "Admin" };
                var roleResult = roleManager.CreateAsync(adminRole).Result;
                var regularUserRole = new IdentityRole { Name = "RegularUser" };
                roleManager.CreateAsync(regularUserRole);

                if (!roleResult.Succeeded)
                    return;

                var user = new ApplicationUser
                {
                    UserName = "Tangooe@user.com",
                    Email = "Tangooe@user.com"
                };

                userManager.CreateAsync(user, "Abc!23");
                userManager.AddToRoleAsync(user, regularUserRole.Name);

                var admin = new ApplicationUser
                {
                    UserName = "Tangooe@admin.com",
                    Email = "Tangooe@admin.com"
                };

                userManager.CreateAsync(admin, "Abc!23");
                userManager.AddToRoleAsync(admin, adminRole.Name);
            }
        }
    }
}
