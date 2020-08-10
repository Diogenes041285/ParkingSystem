using ParkingSystem.Business.Interfaces;
using ParkingSystem.Data.Context;
using ParkingSystem.Model;

namespace ParkingSystem.Data.Repository
{
	public class ManobristaRepository : Repository<Manobrista>, IManobristaRepository
	{

		public ManobristaRepository(SystemDbContext context) : base(context) { }
		
	}
}
