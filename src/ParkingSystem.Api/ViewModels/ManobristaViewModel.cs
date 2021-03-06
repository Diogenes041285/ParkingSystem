﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ParkingSystem.Api.ViewModels
{
	public class ManobristaViewModel
	{
		[Key]
		public Guid Id { get; set; }
		[Required(ErrorMessage = "O campo {0} é obrigatório.")]
		[StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 2)]
		public string Nome { get; set; }
		[Required(ErrorMessage = "O campo {0} é obrigatório.")]
		[StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 11)]
		public string Cpf { get; set; }
		public DateTime DataNascimento { get; set; }
		[Required(ErrorMessage = "O campo {0} é obrigatório.")]
		public DateTime DataCadastro { get; set; }
		public DateTime DataAlterado { get; set; }
		[Required(ErrorMessage = "O campo {0} é obrigatório.")]
		public bool Ativo { get; set; }
	}
}
