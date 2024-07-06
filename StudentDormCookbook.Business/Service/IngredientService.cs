using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using StudentDormCookbook.Business.Interface;
using StudentDormCookbook.Business.Model;
using StudentDormCookbook.Data.Generic;
using StudentDormCooknook.Data.Entity;

namespace StudentDormCookbook.Business.Service
{
	public class IngredientService : IIngredientService
	{
		private readonly IRepository<Ingredient> _repository;
		private readonly IMapper _mapper;

        public IngredientService(IRepository<Ingredient> repository,
			IMapper mapper)
        {
			_mapper = mapper;
			_repository = repository;	
        }

        public async Task<IngredientDTO> CreateIngredient(IngredientDTO ingredient)
		{
			var ingredientEntity = _mapper.Map<Ingredient>(ingredient);
			_repository.Add(ingredientEntity);
			await _repository.SaveAsync();
			return ingredient;
		}

		public async Task<IEnumerable<IngredientDTO>> GetAllIngredients()
		{
			var ingredients = await _repository.GetAll()
				.ProjectTo<IngredientDTO>(_mapper.ConfigurationProvider)
				.ToListAsync();
			return ingredients;
		}

		public async Task<IngredientDTO> UpdateIngredient(int id, IngredientDTO ingredient)
		{
			var ingredientEntity = await _repository.GetByIdAsync(id);
			if(ingredientEntity == null)
			{
				return null;
			}
			_mapper.Map(ingredient, ingredientEntity);
			_repository.Update(ingredientEntity);
			await _repository.SaveAsync();

			return _mapper.Map<IngredientDTO>(ingredientEntity);
		}

		public async Task<IngredientDTO> DeleteIngredient(int id)
		{
			var ingredientEntity = await _repository.GetByIdAsync(id);
			if (ingredientEntity == null)
			{
				return null;
			}
			_repository.Delete(ingredientEntity);
			await _repository.SaveAsync();

			return _mapper.Map<IngredientDTO>(ingredientEntity);
		}
	}
}
