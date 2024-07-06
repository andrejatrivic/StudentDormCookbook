using StudentDormCookbook.Business.Model;

namespace StudentDormCookbook.Business.Interface
{
	public interface IIngredientService
	{
		Task<IngredientDTO> CreateIngredient(IngredientDTO ingredient);
		Task<IEnumerable<IngredientDTO>> GetAllIngredients();
		Task<IngredientDTO> UpdateIngredient(int id, IngredientDTO ingredient);
		Task<IngredientDTO> DeleteIngredient(int id);
	}
}
