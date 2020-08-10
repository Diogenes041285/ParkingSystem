using ParkingSystem.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingSystem.Business.Interfaces
{
	public interface IManobraRepository : IRepository<Manobra>
	{
		Task<IEnumerable<Manobra>> ObterManobristasCarros();
	}
}
