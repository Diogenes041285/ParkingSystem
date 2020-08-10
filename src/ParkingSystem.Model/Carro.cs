using System.Collections.Generic;

namespace ParkingSystem.Model
{
	public class Carro : EntidadeBase
	{
		public string Placa { get; set; }
		public string Marca { get; set; }
		public string Modelo { get; set; }
		public virtual IList<Manobra> Manobras { get; set; }

	}
}
