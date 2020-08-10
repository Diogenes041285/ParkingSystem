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
    public class ManobrasController : ControllerBase
    {
		private readonly IManobraRepository _manobraRepository;
		private readonly IMapper _mapper;

		public ManobrasController(IManobraRepository ManobraRepository, IMapper mapper)
		{
			_manobraRepository = ManobraRepository;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IEnumerable<ManobraViewModel>> ObterTodos()
		{
			var manobra = _mapper.Map<IEnumerable<ManobraViewModel>>(await _manobraRepository.ObterTodos());
			return manobra;
		}

		[HttpGet("{id:guid}")]
		public async Task<ActionResult<ManobraViewModel>> ObterPorId(Guid id)
		{
			var manobra = _mapper.Map<ManobraViewModel>(await _manobraRepository.ObterPorId(id));

			if (manobra == null) return NotFound();

			return manobra;
		}

		[HttpPost]
		public async Task<ActionResult<ManobraViewModel>> Adicionar(ManobraViewModel manobraViewModel)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var manobra = _mapper.Map<Manobra>(manobraViewModel);
			await _manobraRepository.Adicionar(manobra);

			return Ok(manobra);
		}

		[HttpPut("{id:guid}")]
		public async Task<ActionResult<ManobraViewModel>> Atualizar(Guid id, ManobraViewModel ManobraViewModel)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var manobra = _mapper.Map<Manobra>(ManobraViewModel);
			await _manobraRepository.Atualizar(manobra);

			return Ok(manobra);
		}

		[HttpDelete("{id:guid}")]
		public async Task<ActionResult<ManobraViewModel>> Excluir(Guid id)
		{
			var manobra = _mapper.Map<ManobraViewModel>(await _manobraRepository.ObterPorId(id));
			if (manobra == null) return NotFound();

			await _manobraRepository.Remover(id);

			return Ok(manobra);
		}
	}
}