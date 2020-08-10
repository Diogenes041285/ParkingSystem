using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingSystem.Model;

namespace ParkingSystem.Data.Mappings
{
	public class CarroMapping : IEntityTypeConfiguration<Carro>
	{
		public void Configure(EntityTypeBuilder<Carro> builder)
		{
			builder.HasKey(c => c.Id);

			builder.Property(c => c.Placa)
				.IsRequired()
				.HasColumnType("varchar(7)");

			builder.Property(c => c.Marca)
				.IsRequired()
				.HasColumnType("varchar(100)");

			builder.Property(c => c.Modelo)
				.IsRequired()
				.HasColumnType("varchar(100)");

			builder.ToTable("Carros");
		}
	}
}
