using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParkingSystem.Api.ViewModels;
using ParkingSystem.Business.Interfaces;
using ParkingSystem.Model;

namespace ParkingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrosController : ControllerBase
    {
		private readonly ICarroRepository _carroRepository;
		private readonly IMapper _mapper;

		public CarrosController(ICarroRepository carroRepository, IMapper mapper)
		{
			_carroRepository = carroRepository;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IEnumerable<CarroViewModel>> ObterTodos()
		{
			var carro = _mapper.Map<IEnumerable<CarroViewModel>>(await _carroRepository.ObterTodos());
			return carro;
		}

		[HttpGet("{id:guid}")]
		public async Task<ActionResult<CarroViewModel>> ObterPorId(Guid id)
		{
			var carro = _mapper.Map<CarroViewModel>(await _carroRepository.ObterPorId(id));

			if (carro == null) return NotFound();

			return carro;
		}

		[HttpPost]
		public async Task<ActionResult<CarroViewModel>> Adicionar(CarroViewModel carroViewModel)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var carro = _mapper.Map<Carro>(carroViewModel);
			await _carroRepository.Adicionar(carro);

			return Ok(carro);
		}

		[HttpPut("{id:guid}")]
		public async Task<ActionResult<CarroViewModel>> Atualizar(Guid id, CarroViewModel carroViewModel)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var carro = _mapper.Map<Carro>(carroViewModel);
			await _carroRepository.Atualizar(carro);

			return Ok(carro);
		}

		[HttpDelete("{id:guid}")]
		public async Task<ActionResult<CarroViewModel>> Excluir(Guid id)
		{
			var carro = _mapper.Map<CarroViewModel>(await _carroRepository.ObterPorId(id));
			if (carro == null) return NotFound();

			await _carroRepository.Remover(id);

			return Ok(carro);
		}
	}
}