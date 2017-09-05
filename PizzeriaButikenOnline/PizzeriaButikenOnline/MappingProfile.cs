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
            CreateMap<DishFormViewModel, Dish>();
            CreateMap<Dish, DishFormViewModel>();
        }
    }
}
