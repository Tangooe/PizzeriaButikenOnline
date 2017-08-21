using Microsoft.AspNetCore.Identity;
using PizzeriaButikenOnline.Entities;
using PizzeriaButikenOnline.Models;
using System.Collections.Generic;
using System.Linq;

namespace PizzeriaButikenOnline.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            if(!context.Ingredients.Any())
            {
                var ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Skinka" },
                    new Ingredient { Name = "Champinjoner" },
                    new Ingredient { Name = "Annanass" }
                };

                context.Ingredients.AddRange(ingredients);
                context.SaveChanges();

                context.Dishes.AddRange(new List<Dish>
                {
                    new Dish
                    {
                        Name = "Capprisiosa",
                        Description = "Klassisk Italiensk Pizza",
                        Price = 80,
                        Igredients = ingredients.Where(x => x.Name == "Skinka" || x.Name == "Champinjoner").ToList()
                    },
                    new Dish
                    {
                        Name = "Hawaii",
                        Description = "Klassisk Italiensk Pizza",
                        Price = 80,
                        Igredients = ingredients.Where(x => x.Name == "Skinka" || x.Name == "Annanass").ToList()
                    }
                });
                context.SaveChanges();
            }

            var user = new ApplicationUser
            {
                UserName = "Tangooe@user.com",
                Email = "Tangooe@user.com"
            };

            userManager.CreateAsync(user, "Abc!23");
        }
    }
}
