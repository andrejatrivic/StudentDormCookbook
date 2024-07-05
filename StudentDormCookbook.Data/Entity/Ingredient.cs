namespace StudentDormCooknook.Data.Entity
{
	/// <summary>
	/// Ingredients used in recipes
	/// </summary>
	public class Ingredient
	{
		public int Id { get; set; }	
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
