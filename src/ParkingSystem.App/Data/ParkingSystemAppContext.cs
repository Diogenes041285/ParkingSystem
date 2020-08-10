using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ParkingSystem.App.ViewModels
{
    public class ParkingSystemAppContext : DbContext
    {
        public ParkingSystemAppContext (DbContextOptions<ParkingSystemAppContext> options)
            : base(options)
        {
        }

        public DbSet<ParkingSystem.App.ViewModels.CarroViewModel> CarroViewModel { get; set; }
    }
}
