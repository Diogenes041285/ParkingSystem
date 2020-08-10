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
	public class ManobraRepository : Repository<Manobra>, IManobraRepository
	{

		public ManobraRepository(SystemDbContext context) : base(context) { }

		public async Task<IEnumerable<Manobra>> ObterManobristasCarros()
		{
			return await Db.Manobras.AsNoTracking().Include(m => m.Carro).Include(m => m.Manobrista).ToListAsync();
		}
	}
}
