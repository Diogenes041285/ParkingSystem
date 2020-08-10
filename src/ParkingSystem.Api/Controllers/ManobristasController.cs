using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParkingSystem.Api.ViewModels;
using ParkingSystem.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ParkingSystem.Model;

namespace ParkingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManobristasController : ControllerBase
    {
		private readonly IManobristaRepository _manobristaRepository;
		private readonly IMapper _mapper;

		public ManobristasController(IManobristaRepository ManobristaRepository, IMapper mapper)
		{
			_manobristaRepository = ManobristaRepository;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IEnumerable<ManobristaViewModel>> ObterTodos()
		{
			var manobrista = _mapper.Map<IEnumerable<ManobristaViewModel>>(await _manobristaRepository.ObterTodos());
			return manobrista;
		}

		[HttpGet("{id:guid}")]
		public async Task<ActionResult<ManobristaViewModel>> ObterPorId(Guid id)
		{
			var manobrista = _mapper.Map<ManobristaViewModel>(await _manobristaRepository.ObterPorId(id));

			if (manobrista == null) return NotFound();

			return manobrista;
		}

		[HttpPost]
		public async Task<ActionResult<ManobristaViewModel>> Adicionar(ManobristaViewModel manobristaViewModel)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var manobrista = _mapper.Map<Manobrista>(manobristaViewModel);
			await _manobristaRepository.Adicionar(manobrista);

			return Ok(manobrista);
		}

		[HttpPut("{id:guid}")]
		public async Task<ActionResult<ManobristaViewModel>> Atualizar(Guid id, ManobristaViewModel manobristaViewModel)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var manobrista = _mapper.Map<Manobrista>(manobristaViewModel);
			await _manobristaRepository.Atualizar(manobrista);

			return Ok(manobrista);
		}

		[HttpDelete("{id:guid}")]
		public async Task<ActionResult<ManobristaViewModel>> Excluir(Guid id)
		{
			var manobrista = _mapper.Map<ManobristaViewModel>(await _manobristaRepository.ObterPorId(id));
			if (manobrista == null) return NotFound();

			await _manobristaRepository.Remover(id);

			return Ok(manobrista);
		}
	}
}