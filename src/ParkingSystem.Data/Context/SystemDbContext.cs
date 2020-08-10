using Microsoft.EntityFrameworkCore;
using ParkingSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingSystem.Data.Context
{
	public class SystemDbContext : DbContext
	{
		public SystemDbContext(DbContextOptions options) : base(options){}

		public DbSet<Manobra> Manobras { get; set; }
		public DbSet<Manobrista> Manobristas { get; set; }
		public DbSet<Carro> Carros { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(SystemDbContext).Assembly);

			foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
				relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

			base.OnModelCreating(modelBuilder);
		}

	}
}
