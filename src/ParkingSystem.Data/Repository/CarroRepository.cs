using Microsoft.EntityFrameworkCore;
using ParkingSystem.Business.Interfaces;
using ParkingSystem.Data.Context;
using ParkingSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Data.Repository
{
	public class CarroRepository : Repository<Carro>, ICarroRepository
	{

		public CarroRepository(SystemDbContext context) : base(context) { }

		public async Task<IEnumerable<Carro>> ObterCarrosManobristas()
		{
			return await Db.Carros.AsNoTracking().Include(m => m.ManobristaEntrada).Include(m => m.ManobristaSaida).ToListAsync();
		}
	}
}
