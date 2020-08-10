using System;

namespace ParkingSystem.Model
{
	public abstract class EntidadeBase
	{
		public EntidadeBase()
		{
			Id = Guid.NewGuid();
		}

		public Guid Id { get; set; }
		public DateTime DataCadastro { get; set; }
		public DateTime? DataAlterado { get; set; }
		public bool Ativo { get; set; }
	}
}
