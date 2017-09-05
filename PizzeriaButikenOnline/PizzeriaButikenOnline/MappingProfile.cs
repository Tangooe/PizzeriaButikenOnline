using AutoMapper;
using PizzeriaButikenOnline.Models;
using PizzeriaButikenOnline.ViewModels;

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

            CreateMap<CategoryFormViewModel, Category>();
            CreateMap<Category, CategoryFormViewModel>();
        }
    }
}
