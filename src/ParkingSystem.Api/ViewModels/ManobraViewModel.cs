using System;
using System.ComponentModel.DataAnnotations;

namespace ParkingSystem.Api.ViewModels
{
	public class ManobraViewModel
	{
		[Key]
		public Guid Id { get; set; }
		[Required(ErrorMessage = "O campo {0} é obrigatório.")]
		public Guid ManobristaId { get; set; }		
		public ManobristaViewModel Manobrista { get; set; }
		[Required(ErrorMessage = "O campo {0} é obrigatório.")]
		public Guid CarroId { get; set; }
		public CarroViewModel Carro { get; set; }
		public DateTime DataHoraEntrada { get; set; }
		public DateTime DataHoraSaida { get; set; }
		[Required(ErrorMessage = "O campo {0} é obrigatório.")]
		public DateTime DataCadastro { get; set; }
		public DateTime DataAlterado { get; set; }
		[Required(ErrorMessage = "O campo {0} é obrigatório.")]
		public bool Ativo { get; set; }
	}
}
