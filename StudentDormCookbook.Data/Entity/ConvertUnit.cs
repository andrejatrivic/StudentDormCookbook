using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace StudentDormCooknook.Data.Entity
{
	public class ConvertUnit
	{
		public int UnitFromId { get; set; }
		public int UnitToId { get; set; }
		public double Factor { get; set; }

		public virtual Unit Unit { get; set; }
	}

	public class ConvertUnitConfigurationBuilder : IEntityTypeConfiguration<ConvertUnit>
	{
		public ConvertUnitConfigurationBuilder()
		{

		}

		public void Configure(EntityTypeBuilder<ConvertUnit> builder)
		{
			builder.ToTable(nameof(ConvertUnit));
			builder.HasKey(k => new { k.UnitFromId, k.UnitToId });
			builder.HasOne(x => x.Unit)
				.WithMany()
				.HasForeignKey(x => x.UnitFromId)
				.HasForeignKey(x => x.UnitToId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
