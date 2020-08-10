using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParkingSystem.App.Models;
using ParkingSystem.App.ViewModels;
using ParkingSystem.Business.Interfaces;
using ParkingSystem.Model;

namespace ParkingSystem.App.Controllers
{
    public class ManobristasController : Controller
    {
		private readonly IManobristaRepository _manobristaRepository;
		private readonly IMapper _mapper;

		public ManobristasController(IManobristaRepository carroRepository, IMapper mapper)
		{
			_manobristaRepository = carroRepository;
			_mapper = mapper;
		}

		public async Task<IActionResult> Index()
		{
			return View(_mapper.Map<IEnumerable<ManobristaViewModel>>(await _manobristaRepository.ObterTodos()));
		}

		public async Task<IActionResult> Details(Guid id)
		{
			var manobristaViewModel = _mapper.Map<ManobristaViewModel>(await _manobristaRepository.ObterPorId(id));

			if (manobristaViewModel == null)
			{
				return NotFound();
			}

			return View(manobristaViewModel);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ManobristaViewModel manobristaViewModel)
		{
			if (ModelState.IsValid)
			{
				manobristaViewModel.Id = Guid.NewGuid();
				manobristaViewModel.DataCadastro = DateTime.Now;
				await _manobristaRepository.Adicionar(_mapper.Map<Manobrista>(manobristaViewModel));
				return RedirectToAction(nameof(Index));
			}
			return View(manobristaViewModel);
		}

		public async Task<IActionResult> Edit(Guid id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var manobristaViewModel = _mapper.Map<ManobristaViewModel>(await _manobristaRepository.ObterPorId(id));
			if (manobristaViewModel == null)
			{
				return NotFound();
			}
			return View(manobristaViewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Guid id, ManobristaViewModel manobristaViewModel)
		{
			if (id != manobristaViewModel.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					manobristaViewModel.DataAlterado = DateTime.Now;
					await _manobristaRepository.Atualizar(_mapper.Map<Manobrista>(manobristaViewModel));
				}
				catch (DbUpdateConcurrencyException)
				{
					throw;
				}
				return RedirectToAction(nameof(Index));
			}
			return View(manobristaViewModel);
		}

		public async Task<IActionResult> Delete(Guid id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var manobristaViewModel = _mapper.Map<ManobristaViewModel>(await _manobristaRepository.ObterPorId(id));
			if (manobristaViewModel == null)
			{
				return NotFound();
			}

			return View(manobristaViewModel);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Guid id)
		{
			await _manobristaRepository.Remover(id);

			return RedirectToAction("Index");
		}
	}
}
