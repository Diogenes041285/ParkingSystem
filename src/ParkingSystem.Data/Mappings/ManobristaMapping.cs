using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingSystem.Model;

namespace ParkingSystem.Data.Mappings
{
	public class ManobristaMapping : IEntityTypeConfiguration<Manobrista>
	{
		public void Configure(EntityTypeBuilder<Manobrista> builder)
		{
			builder.HasKey(m => m.Id);

			builder.Property(m => m.Nome)
				.IsRequired()
				.HasColumnType("varchar(200)");
						
			builder.Property(m => m.Cpf)
				.IsRequired()
				.HasColumnType("varchar(14)");

			builder.Property(m => m.DataNascimento)
				.HasColumnType("datetime");

			builder.ToTable("Manobristas");
		}
	}
}
