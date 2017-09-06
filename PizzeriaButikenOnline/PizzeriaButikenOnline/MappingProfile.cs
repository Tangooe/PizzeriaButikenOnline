using AutoMapper;
using PizzeriaButikenOnline.Core.Models;
using PizzeriaButikenOnline.Core.ViewModels;

namespace PizzeriaButikenOnline
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Ingredient, IngredientViewModel>();

            CreateMap<IngredientFormViewModel, Ingredient>();
            CreateMap<Ingredient, IngredientFormViewModel >();

            CreateMap<DishFormViewModel, Dish>();
            CreateMap<Dish, DishFormViewModel>();
            CreateMap<Dish, DishViewModel>();

            CreateMap<DishIngredient, IngredientViewModel>();

            CreateMap<CategoryFormViewModel, Category>();
            CreateMap<Category, CategoryFormViewModel>();

            CreateMap<ApplicationUser, CheckoutFormViewModel>();
            CreateMap<CheckoutFormViewModel, AnonymousUserInformation>();
        }
    }
}
