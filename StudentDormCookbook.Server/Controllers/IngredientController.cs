using Microsoft.AspNetCore.Mvc;
using StudentDormCookbook.Business.ErrorHandler;
using StudentDormCookbook.Business.Interface;
using StudentDormCookbook.Business.Model;
using StudentDormCookbook.Business.Service;

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
		public async Task<IActionResult> Create(IngredientDTO ingredient)
		{
			try
			{
				var result = await _service.CreateIngredient(ingredient);
				return Ok(result);
			}
			catch (EntityAlreadyExistsException ex)
			{
				return Conflict(new { message = ex.Message });
			}
		}

		[HttpGet("get")]
		public async Task<IEnumerable<IngredientDTO>> GetAll()
		{
			var ingredients = await _service.GetAllIngredients();
			return ingredients;
		}

		[HttpPatch("update/{id}")]
		public async Task<IActionResult> Update(int id, IngredientDTO ingredient)
		{
			try
			{
				var result = await _service.UpdateIngredient(id, ingredient);
				return Ok(result);
			}
			catch (EntityIsNull ex)
			{
				return Conflict(new { message = ex.Message });
			}
			
		}

		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				var result = await _service.DeleteIngredient(id);
				return Ok(result);
			}
			catch (EntityIsNull ex)
			{
				return Conflict(new { message = ex.Message });
			}
		}
	}
}
