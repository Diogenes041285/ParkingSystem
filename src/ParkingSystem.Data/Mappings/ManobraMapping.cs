using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingSystem.Model;

namespace ParkingSystem.Data.Mappings
{
	public class ManobraMapping : IEntityTypeConfiguration<Manobra>
	{
		public void Configure(EntityTypeBuilder<Manobra> builder)
		{
			builder.HasKey(m => m.Id);

			builder.Property(c => c.DataHoraEntrada).IsRequired(false);
			builder.Property(c => c.DataHoraSaida).IsRequired(false);

			builder.HasOne(m => m.Manobrista)
				.WithMany(m => m.Manobras)
				.HasForeignKey(m => m.ManobristaId);

			builder.HasOne(m => m.Carro)
				.WithMany(c => c.Manobras)
				.HasForeignKey(m => m.CarroId);

			builder.ToTable("Manobras");
		}
	}
}
