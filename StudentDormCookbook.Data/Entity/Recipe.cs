using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace StudentDormCooknook.Data.Entity
{
	public class Recipe
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int CategoryId { get; set; }
		public int UserId { get; set; }
		public DateTime CreatedDate { get; set; }
		public string ImageUrl { get; set; }

		public Category Category { get; set; }
		public User User { get; set; }
	}

	public class RecipeConfigurationBuilder : IEntityTypeConfiguration<Recipe>
	{
        public RecipeConfigurationBuilder()
        {
				
        }

		public void Configure(EntityTypeBuilder<Recipe> builder)
		{
			builder.ToTable(nameof(Recipe));
			builder.HasKey(x => x.Id);
			builder.HasOne(x => x.Category)
				.WithMany()
				.HasForeignKey(x => x.CategoryId)
				.OnDelete(DeleteBehavior.Restrict);
			builder.HasOne(x => x.User)
				.WithMany()
				.HasForeignKey(x => x.UserId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
