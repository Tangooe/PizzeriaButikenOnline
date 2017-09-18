using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using PizzeriaButikenOnline.Core.Models;

namespace PizzeriaButikenOnline.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //if(!context.Database.EnsureCreated())
            //    return;

            if (!context.Ingredients.Any())
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

                //context.Ingredients.AddRange(new List<Ingredient>
                //{
                //    new Ingredient {Name = "Ananas", Price = 5m}, // 1
                //    new Ingredient {Name = "Bearnaisesås", Price = 5m}, // 2
                //    new Ingredient {Name = "Currysås", Price = 5m}, // 3
                //    new Ingredient {Name = "Gräddfil", Price = 5m}, // 4
                //    new Ingredient {Name = "Jalapeños", Price = 5m}, // 5
                //    new Ingredient {Name = "Kebabsås stark", Price = 5m}, // 6
                //    new Ingredient {Name = "Kebabsås mild", Price = 5m}, // 7
                //    new Ingredient {Name = "Köttfärs", Price = 5m}, // 8
                //    new Ingredient {Name = "Mozzarellaost", Price = 5m}, // 9
                //    new Ingredient {Name = "Ost", Price = 5m}, // 10
                //    new Ingredient {Name = "Persilja", Price = 5m}, // 11
                //    new Ingredient {Name = "Rhode Islandsås", Price = 5m}, // 12
                //    new Ingredient {Name = "Sardeller", Price = 5m}, // 13
                //    new Ingredient {Name = "Tacokryddmix", Price = 5m}, // 14
                //    new Ingredient {Name = "Vitlökssås", Price = 5m}, // 15
                //    new Ingredient {Name = "Bacon", Price = 5m}, // 16
                //    new Ingredient {Name = "Curry", Price = 5m}, // 17
                //    new Ingredient {Name = "Feferoni", Price = 5m}, // 18
                //    new Ingredient {Name = "Gorgonzolaost", Price = 5m}, // 19
                //    new Ingredient {Name = "Gurka", Price = 5m}, // 20
                //    new Ingredient {Name = "Kebabkött", Price = 5m}, // 21
                //    new Ingredient {Name = "Köttfärssås", Price = 5m}, // 22
                //    new Ingredient {Name = "Musslor", Price = 5m}, // 23
                //    new Ingredient {Name = "Oxfilé", Price = 5m}, // 24
                //    new Ingredient {Name = "Pesto", Price = 5m}, // 25
                //    new Ingredient {Name = "Räkor", Price = 5m}, // 26
                //    new Ingredient {Name = "Scampi", Price = 5m}, // 27
                //    new Ingredient {Name = "Tacosås", Price = 5m}, // 28
                //    new Ingredient {Name = "Tomatsås", Price = 5m}, // 29
                //    new Ingredient {Name = "Banan", Price = 5m}, // 30
                //    new Ingredient {Name = "Champinjoner", Price = 5m}, // 31
                //    new Ingredient {Name = "Fläskfile", Price = 5m}, // 32
                //    new Ingredient {Name = "Isbergssallad", Price = 5m}, // 33
                //    new Ingredient {Name = "Kycklingfilé", Price = 5m}, // 34
                //    new Ingredient {Name = "Lök", Price = 5m}, // 35
                //    new Ingredient {Name = "Oliver", Price = 5m}, // 36
                //    new Ingredient {Name = "Paprika", Price = 5m}, // 37
                //    new Ingredient {Name = "Salami", Price = 5m}, // 38
                //    new Ingredient {Name = "Skinka", Price = 5m}, // 39
                //    new Ingredient {Name = "Tonfisk", Price = 5m}, // 40
                //    new Ingredient {Name = "Vitlök", Price = 5m}, // 41
                //    new Ingredient {Name = "Ägg", Price = 5m}, // 42
                //    new Ingredient {Name = "Tomater", Price = 5m}, //43
                //});

                #endregion

                context.SaveChanges();
            }

            if(!context.DishIngredients.Any())
            {
                var ingredientList = new List<Ingredient>();
                ingredientList.AddRange(new List<Ingredient>
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
                    new Ingredient {Name = "Champinjoner", Price = 5m}, // 31
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
                    new Ingredient {Name = "Tomater", Price = 5m}, //43
                });

                context.Ingredients.AddRange(ingredientList);
                context.SaveChanges();
                //var ananas = new Ingredient { Name = "Ananas", Price = 5m };
                //var bearnaisesas = new Ingredient { Name = "Bearnaisesås", Price = 5m };
                //var currysas = new Ingredient { Name = "Currysås", Price = 5m };
                //var graddfil = new Ingredient { Name = "Gräddfil", Price = 5m };
                //var jalapenos = new Ingredient { Name = "Jalapeños", Price = 5m };
                //var kebabsasstark = new Ingredient { Name = "Kebabsås stark", Price = 5m };
                //var kebabsåsmild = new Ingredient { Name = "Kebabsås mild", Price = 5m };
                //var kottfars = new Ingredient { Name = "Köttfärs", Price = 5m };
                //var mozzarellaost = new Ingredient { Name = "Mozzarellaost", Price = 5m };
                //var ost = new Ingredient { Name = "Ost", Price = 5m };
                //var persilja = new Ingredient { Name = "Persilja", Price = 5m };
                //var rhodeislandsas = new Ingredient { Name = "Rhode Islandsås", Price = 5m };
                //var sardeller = new Ingredient { Name = "Sardeller", Price = 5m };
                //var tacokryddmix = new Ingredient { Name = "Tacokryddmix", Price = 5m };
                //var vitlokssas = new Ingredient { Name = "Vitlökssås", Price = 5m };
                //var bacon = new Ingredient { Name = "Bacon", Price = 5m };
                //var curry = new Ingredient { Name = "Curry", Price = 5m };
                //var feferoni = new Ingredient { Name = "Feferoni", Price = 5m };
                //var gorgonzolaost = new Ingredient { Name = "Gorgonzolaost", Price = 5m };
                //var gurka = new Ingredient { Name = "Gurka", Price = 5m };
                //var kebabkott = new Ingredient { Name = "Kebabkött", Price = 5m };
                //var kotfarssas = new Ingredient { Name = "Köttfärssås", Price = 5m };
                //var musslor = new Ingredient { Name = "Musslor", Price = 5m };
                //var oxfile = new Ingredient { Name = "Oxfilé", Price = 5m };
                //var pesto = new Ingredient { Name = "Pesto", Price = 5m };
                //var rakor = new Ingredient { Name = "Räkor", Price = 5m };
                //var scampi = new Ingredient { Name = "Scampi", Price = 5m };
                //var tacosas = new Ingredient { Name = "Tacosås", Price = 5m };
                //var tomatsas = new Ingredient { Name = "Tomatsås", Price = 5m };
                //var banan = new Ingredient { Name = "Banan", Price = 5m };
                //var champinjoner = new Ingredient { Name = "Champinjoner", Price = 5m };
                //var flaskfile = new Ingredient { Name = "Fläskfile", Price = 5m };
                //var isbergssallad = new Ingredient { Name = "Isbergssallad", Price = 5m };
                //var kycklingfile = new Ingredient { Name = "Kycklingfilé", Price = 5m };
                //var lok = new Ingredient { Name = "Lök", Price = 5m };
                //var oliver = new Ingredient { Name = "Oliver", Price = 5m };
                //var paprika = new Ingredient { Name = "Paprika", Price = 5m };
                //var salami = new Ingredient { Name = "Salami", Price = 5m };
                //var skinka = new Ingredient { Name = "Skinka", Price = 5m };
                //var tonfisk = new Ingredient { Name = "Tonfisk", Price = 5m };
                //var vitlok = new Ingredient { Name = "Vitlök", Price = 5m };
                //var agg = new Ingredient { Name = "Ägg", Price = 5m };
                //var tomater = new Ingredient { Name = "Tomater", Price = 5m };

                #region Add Dishes
                context.Dishes.AddRange(new List<Dish>
                {
                    new Dish
                    {
                        Name = "Capricciosa", CategoryId = 1, Price = 80m, DishIngredients = new List<DishIngredient>
                        {
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Tomatsås") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Ost") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Skinka") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Champinjoner") }
                        }
                    },
                    new Dish { Name = "Margherita", CategoryId = 1, Price = 70m, DishIngredients = new List<DishIngredient>
                        {
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Tomatsås") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Ost") },
                        }
                    },
                    new Dish { Name = "Al funghi", CategoryId = 1, Price = 75m, DishIngredients = new List<DishIngredient>
                        {
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Tomatsås") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Ost") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Champinjoner") }
                        }
                    },
                    new Dish { Name = "Vesuvio", CategoryId = 1, Price = 75m, DishIngredients = new List<DishIngredient>
                        {
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Tomatsås") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Ost") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Skinka") },
                        }
                    },
                    new Dish { Name = "Kebabpizza", CategoryId = 2, Price = 90m, DishIngredients = new List<DishIngredient>
                        {
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Tomatsås") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Ost") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Kebabkött") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Kebabsås stark") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Kebabsås mild") },
                        }
                    },
                    new Dish { Name = "Kebabpizza special", CategoryId = 2, Price = 95m, DishIngredients = new List<DishIngredient>
                        {
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Tomatsås") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Ost") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Kebabkött") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Kebabsås stark") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Kebabsås mild") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Isbergssallad") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Tomater") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Gurka") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Feferoni") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Lök") },
                        }
                    },
                    new Dish { Name = "Kyckling", CategoryId = 2, Price = 90m, DishIngredients = new List<DishIngredient>
                        {
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Tomatsås") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Ost") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Kycklingfilé") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Ananas") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Curry") },
                        }
                    },
                    new Dish { Name = "Santa Cruz", CategoryId = 2, Price = 95m, DishIngredients = new List<DishIngredient>
                        {
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Tomatsås") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Ost") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Fläskfile") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Tacosås") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Lök") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Paprika") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Persilja") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Jalapeños") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Tacokryddmix") },
                        }
                    },
                    new Dish { Name = "Mexicana", CategoryId = 3, Price = 90m, DishIngredients = new List<DishIngredient>
                        {
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Tomatsås") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Ost") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Köttfärs") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Jalapeños") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Vitlök") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Tacosås") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Tacokryddmix") },
                        }
                    },
                    new Dish { Name = "Azteka", CategoryId = 3, Price = 90m, DishIngredients = new List<DishIngredient>
                        {
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Tomatsås") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Ost") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Skinka") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Gräddfil") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Jalapeños") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Tacokryddmix") },
                        }
                    },
                    new Dish { Name = "Acapulco", CategoryId = 3, Price = 95m, DishIngredients = new List<DishIngredient>
                        {
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Tomatsås") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Ost") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Oxfilé") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Champinjoner") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Lök") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Tacosås") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Vitlök") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Jalapeños") },
                            new DishIngredient { Ingredient = ingredientList.First(i => i.Name == "Tacokryddmix") },
                        }
                    },

                    //Beverages
                    new Dish { Name = "Fanta 2l", CategoryId = 4, Price = 35m },
                    new Dish { Name = "Coca Cola 2l", CategoryId = 4, Price = 35m },
                    new Dish { Name = "Coca Cola Zero 2l", CategoryId = 4, Price = 35m },
                    new Dish { Name = "Sprite 2l", CategoryId = 4, Price = 35m },
                });

                //context.Dishes.AddRange(new List<Dish>
                //{
                //    new Dish
                //    {
                //        Name = "Capricciosa", CategoryId = 1, Price = 80m, DishIngredients = new List<DishIngredient>
                //        {
                //            new DishIngredient { IngredientId = 29 },
                //            new DishIngredient { IngredientId = 10 },
                //            new DishIngredient { IngredientId = 39 },
                //            new DishIngredient { IngredientId = 31 }
                //        }
                //    },
                //    new Dish { Name = "Margherita", CategoryId = 1, Price = 70m, DishIngredients = new List<DishIngredient>
                //        {
                //            new DishIngredient { IngredientId = 29 },
                //            new DishIngredient { IngredientId = 10 },
                //        } 
                //    },
                //    new Dish { Name = "Al funghi", CategoryId = 1, Price = 75m, DishIngredients = new List<DishIngredient>
                //        {
                //            new DishIngredient { IngredientId = 29 },
                //            new DishIngredient { IngredientId = 10 },
                //            new DishIngredient { IngredientId = 31 },
                //        }
                //    },
                //    new Dish { Name = "Vesuvio", CategoryId = 1, Price = 75m, DishIngredients = new List<DishIngredient>
                //        {
                //            new DishIngredient { IngredientId = 29 },
                //            new DishIngredient { IngredientId = 10 },
                //            new DishIngredient { IngredientId = 39 },
                //        }
                //    },
                //    new Dish { Name = "Kebabpizza", CategoryId = 2, Price = 90m, DishIngredients = new List<DishIngredient>
                //        {
                //            new DishIngredient { IngredientId = 29 },
                //            new DishIngredient { IngredientId = 10 },
                //            new DishIngredient { IngredientId = 21 },
                //            new DishIngredient { IngredientId = 6 },
                //            new DishIngredient { IngredientId = 35 },
                //            new DishIngredient { IngredientId = 43 },
                //            new DishIngredient { IngredientId = 18 },
                //        }
                //    },
                //    new Dish { Name = "Kebabpizza special", CategoryId = 2, Price = 95m, DishIngredients = new List<DishIngredient>
                //        {
                //            new DishIngredient { IngredientId = 29 },
                //            new DishIngredient { IngredientId = 10 },
                //            new DishIngredient { IngredientId = 21 },
                //            new DishIngredient { IngredientId = 6 },
                //            new DishIngredient { IngredientId = 7 },
                //            new DishIngredient { IngredientId = 35 },
                //            new DishIngredient { IngredientId = 43 },
                //            new DishIngredient { IngredientId = 18 },
                //            new DishIngredient { IngredientId = 33 },
                //            new DishIngredient { IngredientId = 20 },
                //        }
                //    },
                //    new Dish { Name = "Kyckling", CategoryId = 2, Price = 90m, DishIngredients = new List<DishIngredient>
                //        {
                //            new DishIngredient { IngredientId = 29 },
                //            new DishIngredient { IngredientId = 10 },
                //            new DishIngredient { IngredientId = 34 },
                //            new DishIngredient { IngredientId = 1 },
                //            new DishIngredient { IngredientId = 17 },
                //        }
                //    },
                //    new Dish { Name = "Santa Cruz", CategoryId = 2, Price = 95m, DishIngredients = new List<DishIngredient>
                //        {
                //            new DishIngredient { IngredientId = 29 },
                //            new DishIngredient { IngredientId = 10 },
                //            new DishIngredient { IngredientId = 32 },
                //            new DishIngredient { IngredientId = 28 },
                //            new DishIngredient { IngredientId = 35 },
                //            new DishIngredient { IngredientId = 37 },
                //            new DishIngredient { IngredientId = 11 },
                //            new DishIngredient { IngredientId = 5 },
                //            new DishIngredient { IngredientId = 14 },
                //        }
                //    },
                //    new Dish { Name = "Mexicana", CategoryId = 3, Price = 90m, DishIngredients = new List<DishIngredient>
                //        {
                //            new DishIngredient { IngredientId = 29 },
                //            new DishIngredient { IngredientId = 10 },
                //            new DishIngredient { IngredientId = 8 },
                //            new DishIngredient { IngredientId = 28 },
                //            new DishIngredient { IngredientId = 41 },
                //            new DishIngredient { IngredientId = 5 },
                //            new DishIngredient { IngredientId = 14 },
                //        }
                //    },
                //    new Dish { Name = "Azteka", CategoryId = 3, Price = 90m, DishIngredients = new List<DishIngredient>
                //        {
                //            new DishIngredient { IngredientId = 29 },
                //            new DishIngredient { IngredientId = 10 },
                //            new DishIngredient { IngredientId = 39 },
                //            new DishIngredient { IngredientId = 4 },
                //            new DishIngredient { IngredientId = 5 },
                //            new DishIngredient { IngredientId = 14 },
                //        }
                //    },
                //    new Dish { Name = "Acapulco", CategoryId = 3, Price = 95m, DishIngredients = new List<DishIngredient>
                //        {
                //            new DishIngredient { IngredientId = 29 },
                //            new DishIngredient { IngredientId = 10 },
                //            new DishIngredient { IngredientId = 24 },
                //            new DishIngredient { IngredientId = 31 },
                //            new DishIngredient { IngredientId = 28 },
                //            new DishIngredient { IngredientId = 35 },
                //            new DishIngredient { IngredientId = 41 },
                //            new DishIngredient { IngredientId = 5 },
                //            new DishIngredient { IngredientId = 14 },
                //        }
                //    },

                //    //Beverages
                //    new Dish { Name = "Fanta 2l", CategoryId = 4, Price = 35m },
                //    new Dish { Name = "Coca Cola 2l", CategoryId = 4, Price = 35m },
                //    new Dish { Name = "Coca Cola Zero 2l", CategoryId = 4, Price = 35m },
                //    new Dish { Name = "Sprite 2l", CategoryId = 4, Price = 35m },
                //});

                context.SaveChanges();

                #endregion
            }

            if (!context.Users.Any())
            {
                var adminRole = new IdentityRole { Name = "Admin" };
                var roleResult = roleManager.CreateAsync(adminRole).Result;
                var regularUserRole = new IdentityRole { Name = "RegularUser" };
                roleManager.CreateAsync(regularUserRole).Wait();

                if (!roleResult.Succeeded)
                    return;

                var user = new ApplicationUser
                {
                    UserName = "Tangooe@user.com",
                    Email = "Tangooe@user.com",
                    Name = "Emil Ekman",
                    PhoneNumber = "070 666 66 66",
                    StreetAddress = "Streetroad 1",
                    City = "Springfield",
                    ZipCode = "66666"
                };

                userManager.CreateAsync(user, "Abc!23").Wait();
                userManager.AddToRoleAsync(user, regularUserRole.Name).Wait();

                var admin = new ApplicationUser
                {
                    UserName = "Tangooe@admin.com",
                    Email = "Tangooe@admin.com",
                    Name = "Emil Ekman",
                    PhoneNumber = "070 666 66 66",
                    StreetAddress = "Streetroad 1",
                    City = "Springfield",
                    ZipCode = "66666"
                };

                userManager.CreateAsync(admin, "Abc!23").Wait();
                userManager.AddToRoleAsync(admin, adminRole.Name).Wait();
            }
        }
    }
}
