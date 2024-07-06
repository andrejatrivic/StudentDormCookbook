using AutoMapper;
using StudentDormCookbook.Business.Model;
using StudentDormCooknook.Data.Entity;

namespace StudentDormCookbook.Business.Mapper
{
	public class IngredientProfile : Profile
	{
        public IngredientProfile()
        {
            CreateMap<IngredientDTO, Ingredient>();
            CreateMap<Ingredient, IngredientDTO>();
        }
    }
}
