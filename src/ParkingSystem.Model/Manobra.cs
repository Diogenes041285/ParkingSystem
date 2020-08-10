using System;

namespace ParkingSystem.Model
{
	public class Manobra : EntidadeBase
	{
		public Guid ManobristaId { get; set; }
		public Manobrista Manobrista { get; set; }
		public Guid CarroId { get; set; }
		public Carro Carro { get; set; }
		public DateTime? DataHoraEntrada { get; set; }
		public DateTime? DataHoraSaida { get; set; }
	}
}
