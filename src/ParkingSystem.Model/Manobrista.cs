using System;
using System.Collections.Generic;

namespace ParkingSystem.Model
{
	public class Manobrista : EntidadeBase
	{
		public string Nome { get; set; }
		public string Cpf { get; set; }
		public DateTime DataNascimento { get; set; }
		public virtual IList<Carro> CarrosEntrada { get; set; }
		public virtual IList<Carro> CarrosSaida{ get; set; }
	}
}
