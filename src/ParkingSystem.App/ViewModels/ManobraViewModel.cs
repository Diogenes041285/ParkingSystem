using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingSystem.App.ViewModels
{
	public class ManobraViewModel
	{
		[Key]
		public Guid Id { get; set; }
		[Required(ErrorMessage = "O campo {0} é obrigatório.")]
		[DisplayName("Manobrista Responsável")]
		public Guid ManobristaId { get; set; }
		[DisplayName("Manobrista Responsável")]
		public ManobristaViewModel Manobrista { get; set; }
		[Required(ErrorMessage = "O campo {0} é obrigatório.")]
		[DisplayName("Carro")]
		public Guid CarroId { get; set; }
		public CarroViewModel Carro { get; set; }
		[DisplayName("Data Hora Entrada")]
		public DateTime DataHoraEntrada { get; set; }
		[DisplayName("Data Hora Saída")]
		public DateTime DataHoraSaida { get; set; }		
		public DateTime DataCadastro { get; set; }
		public DateTime DataAlterado { get; set; }
		[Required(ErrorMessage = "O campo {0} é obrigatório.")]
		public bool Ativo { get; set; }
		[NotMapped]
		public IEnumerable<ManobristaViewModel> Manobristas { get; set; }
		[NotMapped]
		public IEnumerable<CarroViewModel> Carros { get; set; }
	}
}
