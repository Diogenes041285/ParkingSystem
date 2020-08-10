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
    public class ManobrasController : Controller
    {
		private readonly IManobraRepository _manobraRepository;
		private readonly IManobristaRepository _manobristaRepository;
		private readonly ICarroRepository _carroRepository;
		private readonly IMapper _mapper;

		public ManobrasController(IManobraRepository manobraRepository, IManobristaRepository manobristaRepository, ICarroRepository carroRepository, IMapper mapper)
		{
			_manobraRepository = manobraRepository;
			_manobristaRepository = manobristaRepository;
			_carroRepository = carroRepository;
			_mapper = mapper;
		}

		public async Task<IActionResult> Index()
		{
			return View(_mapper.Map<IEnumerable<ManobraViewModel>>(await _manobraRepository.ObterManobristasCarros()));
		}

		public async Task<IActionResult> Details(Guid id)
		{
			var manobraViewModel = _mapper.Map<ManobraViewModel>(await _manobraRepository.ObterPorId(id));
			
			if (manobraViewModel == null)
			{
				return NotFound();
			}

			return View(manobraViewModel);
		}

		public async Task<IActionResult> Create()
		{
			var manobraViewModel = new ManobraViewModel();			
			manobraViewModel.Manobristas = _mapper.Map<IEnumerable<ManobristaViewModel>>(await _manobristaRepository.ObterTodos());
			manobraViewModel.Carros = _mapper.Map<IEnumerable<CarroViewModel>>(await _carroRepository.ObterTodos());

			return View(manobraViewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ManobraViewModel manobraViewModel)
		{
			if (ModelState.IsValid)
			{
				manobraViewModel.Id = Guid.NewGuid();
				manobraViewModel.DataCadastro = DateTime.Now;
				await _manobraRepository.Adicionar(_mapper.Map<Manobra>(manobraViewModel));
				return RedirectToAction(nameof(Index));
			}
			return View(manobraViewModel);
		}

		public async Task<IActionResult> Edit(Guid id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var manobraViewModel = _mapper.Map<ManobraViewModel>(await _manobraRepository.ObterPorId(id));			
			if (manobraViewModel == null)
			{
				return NotFound();
			}
			return View(manobraViewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Guid id, ManobraViewModel manobraViewModel)
		{
			if (id != manobraViewModel.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					manobraViewModel.DataCadastro = DateTime.Now;
					await _manobraRepository.Atualizar(_mapper.Map<Manobra>(manobraViewModel));
				}
				catch (DbUpdateConcurrencyException)
				{
					throw;
				}
				return RedirectToAction(nameof(Index));
			}
			return View(manobraViewModel);
		}

		public async Task<IActionResult> Delete(Guid id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var manobraViewModel = _mapper.Map<ManobraViewModel>(await _manobraRepository.ObterPorId(id));
			if (manobraViewModel == null)
			{
				return NotFound();
			}

			return View(manobraViewModel);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Guid id)
		{
			await _manobraRepository.Remover(id);

			return RedirectToAction("Index");
		}
	}
}
