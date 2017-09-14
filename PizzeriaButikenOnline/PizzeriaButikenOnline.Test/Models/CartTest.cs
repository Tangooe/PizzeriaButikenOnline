using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzeriaButikenOnline.Core.Models;
using PizzeriaButikenOnline.Core.ViewModels;
using System.Collections.Generic;

namespace PizzeriaButikenOnline.Test.Models
{
    [TestClass]
    public class CartTest
    {
        private readonly Cart _cart;
        public CartTest()
        {
            _cart = new Cart();
            _cart.AddItem(new DishViewModel
            {
                Id = 1,
                Category = new Category
                {
                    Id = 1,
                    Name = "Pizzor"
                },
                DishNumber = 1,
                Name = "Margharita",
                Price = 70,
                Ingredients = new List<IngredientViewModel>
                {
                    new IngredientViewModel
                    {
                        Id = 1,
                        IsDefault = true,
                        IsSelected = true,
                        Name = "Ost",
                        Price = 5
                    },
                    new IngredientViewModel
                    {
                        Id = 1,
                        IsDefault = true,
                        IsSelected = true,
                        Name = "Tomatsås",
                        Price = 5
                    }
                }
            }, 1);
            _cart.AddItem(new DishViewModel
            {
                Id = 2,
                Category = new Category
                {
                    Id = 1,
                    Name = "Pizzor"
                },
                DishNumber = 1,
                Name = "TorrPizza",
                Price = 70,
                Ingredients = new List<IngredientViewModel>
                {
                    new IngredientViewModel
                    {
                        Id = 1,
                        IsDefault = true,
                        IsSelected = true,
                        Name = "Ost",
                        Price = 5
                    },
                    new IngredientViewModel
                    {
                        Id = 3,
                        IsDefault = true,
                        IsSelected = true,
                        Name = "Skinka",
                        Price = 5
                    }
                }
            }, 1);
        }

        [TestMethod]
        public void ComputeTotalValue_TotalDishValue140_ShouldReturn140()
        {
            _cart.ComputeTotalValue().Should().Be(140);
        }
    }
}
