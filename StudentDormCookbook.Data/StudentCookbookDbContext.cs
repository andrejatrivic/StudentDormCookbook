using Microsoft.EntityFrameworkCore;
using StudentDormCooknook.Data.Entity;
using System.Reflection;

namespace StudentDormCooknook.Data
{
	public class StudentCookbookDbContext : DbContext
	{
        public StudentCookbookDbContext(DbContextOptions<StudentCookbookDbContext> options) : base(options)
        {

        }

		public DbSet<Category> Categories { get; set; }
		public DbSet<ConvertUnit> ConvertUnits { get; set; }
		public DbSet<Ingredient> Ingredients { get; set; }
		public DbSet<Recipe> Recipes { get; set; }
		public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
		public DbSet<Unit> Units { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
