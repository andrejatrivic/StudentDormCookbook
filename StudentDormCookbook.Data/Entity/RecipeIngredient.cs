using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentDormCooknook.Data.Entity
{
	public class RecipeIngredient
	{
		public int Id { get; set; }
		public int IngredientId { get; set; }
		public int RecipeId { get; set; }
		public int UnitId { get; set; }
		public double Quantity { get; set; }

		public Ingredient Ingredient { get; set; }
		public Recipe Recipe { get; set; }
		public Unit Unit { get; set; }
	}

	public class RecipeIngredientConfigurationBuilder : IEntityTypeConfiguration<RecipeIngredient> 
	{
        public RecipeIngredientConfigurationBuilder()
        {
				
        }

		public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
		{
			builder.ToTable(nameof(RecipeIngredient));
			builder.HasKey(x => x.Id);
			builder.HasOne(x => x.Ingredient)
				.WithMany()
				.HasForeignKey(x => x.IngredientId)
				.OnDelete(DeleteBehavior.Restrict);
			builder.HasOne(x => x.Recipe)
				.WithMany()
				.HasForeignKey(x => x.RecipeId)
				.OnDelete(DeleteBehavior.Restrict);
			builder.HasOne(x => x.Unit)
				.WithMany()
				.HasForeignKey(x => x.UnitId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
