﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParkingSystem.Api.ViewModels
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
		[Required(ErrorMessage = "O campo {0} é obrigatório.")]
		public DateTime DataCadastro { get; set; }
		public DateTime DataAlterado { get; set; }
		[Required(ErrorMessage = "O campo {0} é obrigatório.")]
		public bool Ativo { get; set; }
		public virtual IList<ManobraViewModel> Manobras { get; set; }
	}
}
