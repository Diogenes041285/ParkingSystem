using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParkingSystem.App.ViewModels;

namespace ParkingSystem.App.Models
{
    public class ParkingSystemAppContext2 : DbContext
    {
        public ParkingSystemAppContext2 (DbContextOptions<ParkingSystemAppContext2> options)
            : base(options)
        {
        }

        public DbSet<ParkingSystem.App.ViewModels.ManobristaViewModel> ManobristaViewModel { get; set; }

        public DbSet<ParkingSystem.App.ViewModels.ManobraViewModel> ManobraViewModel { get; set; }
    }
}
