using Microsoft.AspNetCore.Identity;
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

                context.Categories.AddRange(categories);
                context.SaveChanges();

                var ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Ananas" , Price = 5m },
                    new Ingredient { Name = "Bearnaisesås" , Price = 5m },
                    new Ingredient { Name = "Currysås" , Price = 5m },
                    new Ingredient { Name = "Gräddfil" , Price = 5m },
                    new Ingredient { Name = "Jalapeños" , Price = 5m },
                    new Ingredient { Name = "Kebabsås stark" , Price = 5m },
                    new Ingredient { Name = "Kebabsås mild" , Price = 5m },
                    new Ingredient { Name = "Köttfärs" , Price = 5m },
                    new Ingredient { Name = "Mozzarellaost" , Price = 5m },
                    new Ingredient { Name = "Ost" , Price = 5m },
                    new Ingredient { Name = "Persilja" , Price = 5m },
                    new Ingredient { Name = "Rhode Islandsås" , Price = 5m },
                    new Ingredient { Name = "Sardeller" , Price = 5m },
                    new Ingredient { Name = "Tacokryddmix" , Price = 5m },
                    new Ingredient { Name = "Vitlökssås" , Price = 5m },
                    new Ingredient { Name = "Bacon" , Price = 5m },
                    new Ingredient { Name = "Curry" , Price = 5m },
                    new Ingredient { Name = "Feferoni" , Price = 5m },
                    new Ingredient { Name = "Gorgonzolaost" , Price = 5m },
                    new Ingredient { Name = "Gurka" , Price = 5m },
                    new Ingredient { Name = "Kebabkött" , Price = 5m },
                    new Ingredient { Name = "Köttfärssås" , Price = 5m },
                    new Ingredient { Name = "Musslor" , Price = 5m },
                    new Ingredient { Name = "Oxfilé" , Price = 5m },
                    new Ingredient { Name = "Pesto" , Price = 5m },
                    new Ingredient { Name = "Räkor" , Price = 5m },
                    new Ingredient { Name = "Scampi" , Price = 5m },
                    new Ingredient { Name = "Tacosås" , Price = 5m },
                    new Ingredient { Name = "Tomatsås" , Price = 5m },
                    new Ingredient { Name = "Banan" , Price = 5m },
                    new Ingredient { Name = "Champinjoner" , Price = 5m },
                    new Ingredient { Name = "Fläskfile" , Price = 5m },
                    new Ingredient { Name = "Isbergssallad" , Price = 5m },
                    new Ingredient { Name = "Kycklingfilé" , Price = 5m },
                    new Ingredient { Name = "Lök" , Price = 5m },
                    new Ingredient { Name = "Oliver" , Price = 5m },
                    new Ingredient { Name = "Paprika" , Price = 5m },
                    new Ingredient { Name = "Salami" , Price = 5m },
                    new Ingredient { Name = "Skinka" , Price = 5m },
                    new Ingredient { Name = "Tonfisk" , Price = 5m },
                    new Ingredient { Name = "Vitlök" , Price = 5m },
                    new Ingredient { Name = "Ägg" , Price = 5m }
                };

                context.Ingredients.AddRange(ingredients);
                context.SaveChanges();

                context.Dishes.AddRange(new List<Dish>
                {
                    new Dish
                    {
                        Name = "Capprisiosa",
                        Category = categories.First(x => x.Name =="Italienska Pizzor"),
                        Price = 80,
                        Ingredients = ingredients.Where(x =>
                            x.Name == "Skinka" ||
                            x.Name == "Champinjoner")
                            .ToList()
                    },
                    new Dish
                    {
                        Name = "Hawaii",
                        Price = 80,
                        Category = categories.First(x => x.Name =="Italienska Pizzor"),
                        Ingredients = ingredients.Where(x => 
                            x.Name == "Skinka" || 
                            x.Name == "Ananas")
                            .ToList()
                    },
                    new Dish
                    {
                        Name = "Kebab Pizza",
                        Price = 85,
                        Category = categories.First(x => x.Name == "Kebab Pizzor"),
                        Ingredients = ingredients.Where(x => 
                            x.Name == "Kebab" ||
                            x.Name == "Kebabsås")
                            .ToList()
                    }
                });
                context.SaveChanges();
            }

            if (context.Users.Any())
                return;

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
