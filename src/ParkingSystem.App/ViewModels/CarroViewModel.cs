using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingSystem.App.ViewModels
{
	public class CarroViewModel
	{
		[Key]
		public Guid Id { get; set; }
		[Required(ErrorMessage = "O campo {0} é obrigatório.")]
		[StringLength(7, ErrorMessage = "O campo {0} precisa ter {1} caracteres.")]
		public string Placa { get; set; }
		[Required(ErrorMessage = "O campo {0} é obrigatório.")]
		[StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 2)]
		public string Marca { get; set; }
		[Required(ErrorMessage = "O campo {0} é obrigatório.")]
		[StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 2)]
		public string Modelo { get; set; }
		[DisplayName("Manobrista Entrada")]
		public Guid ManobristaEntradaId { get; set; }
		[DisplayName("Manobrista Entrada")]
		public ManobristaViewModel ManobristaEntrada { get; set; }
		[DisplayName("Manobrista Saída")]
		public Guid? ManobristaSaidaId { get; set; }
		[DisplayName("Manobrista Saída")]
		public ManobristaViewModel ManobristaSaida { get; set; }
		[DisplayName("Data Hora Entrada")]
		public DateTime? DataHoraEntrada { get; set; }
		[DisplayName("Data Hora Saída")]
		public DateTime? DataHoraSaida { get; set; }
		public DateTime DataCadastro { get; set; }
		public DateTime DataAlterado { get; set; }
		[Required(ErrorMessage = "O campo {0} é obrigatório.")]
		public bool Ativo { get; set; }
		[NotMapped]
		public IEnumerable<ManobristaViewModel> Manobristas { get; set; }
	}
}
