using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParkingSystem.App.ViewModels;
using ParkingSystem.Business.Interfaces;
using ParkingSystem.Model;

namespace ParkingSystem.App.Controllers
{
	public class CarrosController : Controller
	{
		private readonly ICarroRepository _carroRepository;
		private readonly IManobristaRepository _manobristaRepository;
		private readonly IMapper _mapper;

		public CarrosController(ICarroRepository carroRepository, IManobristaRepository manobristaRepository, IMapper mapper)
		{
			_carroRepository = carroRepository;
			_manobristaRepository = manobristaRepository;
			_mapper = mapper;
		}

		public async Task<IActionResult> Index()
		{
			return View(_mapper.Map<IEnumerable<CarroViewModel>>(await _carroRepository.ObterCarrosManobristas()));
		}

		public async Task<IActionResult> Details(Guid id)
		{
			var carroViewModel = _mapper.Map<CarroViewModel>(await _carroRepository.ObterPorId(id));

			if (carroViewModel == null)
			{
				return NotFound();
			}

			return View(carroViewModel);
		}

		public async Task<IActionResult> Create()
		{
			var carroViewModel = new CarroViewModel();
			carroViewModel.Manobristas = _mapper.Map<IEnumerable<ManobristaViewModel>>(await _manobristaRepository.ObterTodos());
			return View(carroViewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CarroViewModel carroViewModel)
		{
			if (ModelState.IsValid)
			{
				carroViewModel.Id = Guid.NewGuid();
				carroViewModel.DataCadastro = DateTime.Now;
				await _carroRepository.Adicionar(_mapper.Map<Carro>(carroViewModel));
				return RedirectToAction(nameof(Index));
			}
			return View(carroViewModel);
		}

		public async Task<IActionResult> Edit(Guid id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var carroViewModel = _mapper.Map<CarroViewModel>(await _carroRepository.ObterPorId(id));
			carroViewModel.Manobristas = _mapper.Map<IEnumerable<ManobristaViewModel>>(await _manobristaRepository.ObterTodos());
			if (carroViewModel == null)
			{
				return NotFound();
			}
			return View(carroViewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Guid id, CarroViewModel carroViewModel)
		{
			if (id != carroViewModel.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					carroViewModel.DataAlterado = DateTime.Now;
					await _carroRepository.Atualizar(_mapper.Map<Carro>(carroViewModel));
				}
				catch (DbUpdateConcurrencyException)
				{
					throw;
				}
				return RedirectToAction(nameof(Index));
			}
			return View(carroViewModel);
		}

		public async Task<IActionResult> Delete(Guid id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var carroViewModel = _mapper.Map<CarroViewModel>(await _carroRepository.ObterPorId(id));
			if (carroViewModel == null)
			{
				return NotFound();
			}

			return View(carroViewModel);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Guid id)
		{
			await _carroRepository.Remover(id);

			return RedirectToAction("Index");
		}				

	}
}
