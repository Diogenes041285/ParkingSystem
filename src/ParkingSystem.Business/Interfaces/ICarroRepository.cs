using ParkingSystem.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingSystem.Business.Interfaces
{
	public interface ICarroRepository : IRepository<Carro>
	{
		Task<IEnumerable<Carro>> ObterCarrosManobristas();
	}
}
