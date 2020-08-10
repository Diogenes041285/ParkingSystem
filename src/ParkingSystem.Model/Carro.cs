using System;
using System.Collections.Generic;

namespace ParkingSystem.Model
{
	public class Carro : EntidadeBase
	{
		public string Placa { get; set; }
		public string Marca { get; set; }
		public string Modelo { get; set; }
		public Guid ManobristaEntradaId { get; set; }
		public Manobrista ManobristaEntrada { get; set; }
		public Guid? ManobristaSaidaId { get; set; }
		public Manobrista ManobristaSaida { get; set; }
		public DateTime? DataHoraEntrada { get; set; }
		public DateTime? DataHoraSaida { get; set; }

	}
}
