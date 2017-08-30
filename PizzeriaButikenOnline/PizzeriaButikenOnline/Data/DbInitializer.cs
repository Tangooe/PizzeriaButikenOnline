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
            if(!context.Database.EnsureCreated())
                return;

            if(!context.Ingredients.Any())
            {
                #region Add Categories

                context.Categories.AddRange(new List<Category>
                {
                    new Category {Name = "Italienska Pizzor"},
                    new Category {Name = "Specialpizzor"},
                    new Category {Name = "Mexikanska pizzor"},
                    new Category {Name = "Drycker"},
                    new Category {Name = "Sallader"},
                    new Category {Name = "Såser"}
                });

                #endregion

                #region Add Ingredients

                context.Ingredients.AddRange(new List<Ingredient>
                {
                    new Ingredient {Name = "Ananas", Price = 5m}, // 1
                    new Ingredient {Name = "Bearnaisesås", Price = 5m}, // 2
                    new Ingredient {Name = "Currysås", Price = 5m}, // 3
                    new Ingredient {Name = "Gräddfil", Price = 5m}, // 4
                    new Ingredient {Name = "Jalapeños", Price = 5m}, // 5
                    new Ingredient {Name = "Kebabsås stark", Price = 5m}, // 6
                    new Ingredient {Name = "Kebabsås mild", Price = 5m}, // 7
                    new Ingredient {Name = "Köttfärs", Price = 5m}, // 8
                    new Ingredient {Name = "Mozzarellaost", Price = 5m}, // 9
                    new Ingredient {Name = "Ost", Price = 5m}, // 10
                    new Ingredient {Name = "Persilja", Price = 5m}, // 11
                    new Ingredient {Name = "Rhode Islandsås", Price = 5m}, // 12
                    new Ingredient {Name = "Sardeller", Price = 5m}, // 13
                    new Ingredient {Name = "Tacokryddmix", Price = 5m}, // 14
                    new Ingredient {Name = "Vitlökssås", Price = 5m}, // 15
                    new Ingredient {Name = "Bacon", Price = 5m}, // 16
                    new Ingredient {Name = "Curry", Price = 5m}, // 17
                    new Ingredient {Name = "Feferoni", Price = 5m}, // 18
                    new Ingredient {Name = "Gorgonzolaost", Price = 5m}, // 19
                    new Ingredient {Name = "Gurka", Price = 5m}, // 20
                    new Ingredient {Name = "Kebabkött", Price = 5m}, // 21
                    new Ingredient {Name = "Köttfärssås", Price = 5m}, // 22
                    new Ingredient {Name = "Musslor", Price = 5m}, // 23
                    new Ingredient {Name = "Oxfilé", Price = 5m}, // 24
                    new Ingredient {Name = "Pesto", Price = 5m}, // 25
                    new Ingredient {Name = "Räkor", Price = 5m}, // 26
                    new Ingredient {Name = "Scampi", Price = 5m}, // 27
                    new Ingredient {Name = "Tacosås", Price = 5m}, // 28
                    new Ingredient {Name = "Tomatsås", Price = 5m}, // 29
                    new Ingredient {Name = "Banan", Price = 5m}, // 30
                    new Ingredient {Name = "Champinjoner", Price = 5m }, // 31
                    new Ingredient {Name = "Fläskfile", Price = 5m}, // 32
                    new Ingredient {Name = "Isbergssallad", Price = 5m}, // 33
                    new Ingredient {Name = "Kycklingfilé", Price = 5m}, // 34
                    new Ingredient {Name = "Lök", Price = 5m}, // 35
                    new Ingredient {Name = "Oliver", Price = 5m}, // 36
                    new Ingredient {Name = "Paprika", Price = 5m}, // 37
                    new Ingredient {Name = "Salami", Price = 5m}, // 38
                    new Ingredient {Name = "Skinka", Price = 5m}, // 39
                    new Ingredient {Name = "Tonfisk", Price = 5m}, // 40
                    new Ingredient {Name = "Vitlök", Price = 5m}, // 41
                    new Ingredient {Name = "Ägg", Price = 5m}, // 42
                    new Ingredient {Name = "Tomater", Price = 5m }, //43
                });

#endregion

                context.SaveChanges();

                #region Add Dishes

                context.Dishes.AddRange(new List<Dish>
                {
                    new Dish { Name = "Capricciosa", CategoryId = 1, Price = 80m },
                    new Dish { Name = "Margherita", CategoryId = 1, Price = 70m },
                    new Dish { Name = "Al funghi", CategoryId = 1, Price = 75m },
                    new Dish { Name = "Vesuvio", CategoryId = 1, Price = 75m },
                    new Dish { Name = "Kebabpizza", CategoryId = 2, Price = 90m },
                    new Dish { Name = "Kebabpizza special", CategoryId = 2, Price = 95m },
                    new Dish { Name = "Kyckling", CategoryId = 2, Price = 90m },
                    new Dish { Name = "Santa Cruz", CategoryId = 2, Price = 95m },
                    new Dish { Name = "Mexicana", CategoryId = 3, Price = 90m },
                    new Dish { Name = "Azteka", CategoryId = 3, Price = 90m },
                    new Dish { Name = "Acapulco", CategoryId = 3, Price = 95m },

                    //Beverages
                    new Dish { Name = "Fanta 2l", CategoryId = 4, Price = 35m },
                    new Dish { Name = "Coca Cola 2l", CategoryId = 4, Price = 35m },
                    new Dish { Name = "Coca Cola Zero 2l", CategoryId = 4, Price = 35m },
                    new Dish { Name = "Sprite 2l", CategoryId = 4, Price = 35m },
                });


                #endregion

                #region Add DishIngredients

                context.DishIngredients.AddRange(new List<DishIngredient>
                {
                    //Capprisiosa
                    new DishIngredient { DishId = 1, IngredientId = 29 },
                    new DishIngredient { DishId = 1, IngredientId = 10 },
                    new DishIngredient { DishId = 1, IngredientId = 39 },
                    new DishIngredient { DishId = 1, IngredientId = 31 },
                    //Margherita
                    new DishIngredient { DishId = 2, IngredientId = 29 },
                    new DishIngredient { DishId = 2, IngredientId = 10 },
                    //Al funghi
                    new DishIngredient { DishId = 3, IngredientId = 29 },
                    new DishIngredient { DishId = 3, IngredientId = 10 },
                    new DishIngredient { DishId = 3, IngredientId = 31 },
                    //Vesuvio
                    new DishIngredient { DishId = 4, IngredientId = 29 },
                    new DishIngredient { DishId = 4, IngredientId = 10 },
                    new DishIngredient { DishId = 4, IngredientId = 39 },
                    //Kebabpizza
                    new DishIngredient { DishId = 5, IngredientId = 29 },
                    new DishIngredient { DishId = 5, IngredientId = 10 },
                    new DishIngredient { DishId = 5, IngredientId = 21 },
                    new DishIngredient { DishId = 5, IngredientId = 6 },
                    new DishIngredient { DishId = 5, IngredientId = 35 },
                    new DishIngredient { DishId = 5, IngredientId = 43 },
                    new DishIngredient { DishId = 5, IngredientId = 18 },
                    //Kebabpizza Special
                    new DishIngredient { DishId = 6, IngredientId = 29 },
                    new DishIngredient { DishId = 6, IngredientId = 10 },
                    new DishIngredient { DishId = 6, IngredientId = 21 },
                    new DishIngredient { DishId = 6, IngredientId = 6 },
                    new DishIngredient { DishId = 6, IngredientId = 7 },
                    new DishIngredient { DishId = 6, IngredientId = 35 },
                    new DishIngredient { DishId = 6, IngredientId = 43 },
                    new DishIngredient { DishId = 6, IngredientId = 18 },
                    new DishIngredient { DishId = 6, IngredientId = 33 },
                    new DishIngredient { DishId = 6, IngredientId = 20 },
                    //Kyckling
                    new DishIngredient { DishId = 7, IngredientId = 29 },
                    new DishIngredient { DishId = 7, IngredientId = 10 },
                    new DishIngredient { DishId = 7, IngredientId = 34 },
                    new DishIngredient { DishId = 7, IngredientId = 1 },
                    new DishIngredient { DishId = 7, IngredientId = 17 },
                    //Santa Cruz
                    new DishIngredient { DishId = 8, IngredientId = 29 },
                    new DishIngredient { DishId = 8, IngredientId = 10 },
                    new DishIngredient { DishId = 8, IngredientId = 32 },
                    new DishIngredient { DishId = 8, IngredientId = 28 },
                    new DishIngredient { DishId = 8, IngredientId = 35 },
                    new DishIngredient { DishId = 8, IngredientId = 37 },
                    new DishIngredient { DishId = 8, IngredientId = 11 },
                    new DishIngredient { DishId = 8, IngredientId = 5 },
                    new DishIngredient { DishId = 8, IngredientId = 14 },
                    //Mexicana
                    new DishIngredient { DishId = 9, IngredientId = 29 },
                    new DishIngredient { DishId = 9, IngredientId = 10 },
                    new DishIngredient { DishId = 9, IngredientId = 8 },
                    new DishIngredient { DishId = 9, IngredientId = 28 },
                    new DishIngredient { DishId = 9, IngredientId = 41 },
                    new DishIngredient { DishId = 9, IngredientId = 5 },
                    new DishIngredient { DishId = 9, IngredientId = 14 },
                    //Azteka
                    new DishIngredient { DishId = 10, IngredientId = 29 },
                    new DishIngredient { DishId = 10, IngredientId = 10 },
                    new DishIngredient { DishId = 10, IngredientId = 39 },
                    new DishIngredient { DishId = 10, IngredientId = 4 },
                    new DishIngredient { DishId = 10, IngredientId = 5 },
                    new DishIngredient { DishId = 10, IngredientId = 14 },
                    //Acapulco
                    new DishIngredient { DishId = 11, IngredientId = 29 },
                    new DishIngredient { DishId = 11, IngredientId = 10 },
                    new DishIngredient { DishId = 11, IngredientId = 24 },
                    new DishIngredient { DishId = 11, IngredientId = 31 },
                    new DishIngredient { DishId = 11, IngredientId = 28 },
                    new DishIngredient { DishId = 11, IngredientId = 35 },
                    new DishIngredient { DishId = 11, IngredientId = 41 },
                    new DishIngredient { DishId = 11, IngredientId = 5 },
                    new DishIngredient { DishId = 11, IngredientId = 14 },
                });

                #endregion

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
