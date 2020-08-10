using ParkingSystem.Business.Interfaces;
using ParkingSystem.Data.Context;
using ParkingSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingSystem.Data.Repository
{
	public class CarroRepository : Repository<Carro>, ICarroRepository
	{

		public CarroRepository(SystemDbContext context) : base(context) { }
	}
}
