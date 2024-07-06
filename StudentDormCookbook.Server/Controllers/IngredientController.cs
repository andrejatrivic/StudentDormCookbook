using Microsoft.AspNetCore.Mvc;
using StudentDormCookbook.Business.Interface;
using StudentDormCookbook.Business.Model;

namespace StudentDormCookbook.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class IngredientController : ControllerBase
	{
		private readonly IIngredientService _service;

        public IngredientController(IIngredientService service)
        {
            _service = service;
        }

		[HttpPost("create")]
		public async Task<IngredientDTO> Create(IngredientDTO ingredient)
		{
			var createdIngredient = await _service.CreateIngredient(ingredient);
			return createdIngredient;
		}

		[HttpGet("get")]
		public async Task<IEnumerable<IngredientDTO>> GetAll()
		{
			var ingredients = await _service.GetAllIngredients();
			return ingredients;
		}

		[HttpPatch("update/{id}")]
		public async Task<IngredientDTO> Update(int id, IngredientDTO ingredient)
		{
			var updatedIngredient = await _service.UpdateIngredient(id, ingredient);
			return updatedIngredient;
		}

		[HttpDelete("delete/{id}")]
		public async Task<IngredientDTO> Delete(int id)
		{
			var deletedIngredient = await _service.DeleteIngredient(id);
			return deletedIngredient;
		}
	}
}
