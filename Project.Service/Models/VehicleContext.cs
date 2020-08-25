using Microsoft.EntityFrameworkCore;
using Project.Service.Contractors;
using Project.Service.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service.Models
{
    public class VehicleContext : DbContext
    {
        public VehicleContext(DbContextOptions<VehicleContext> options):base(options)
        {

        }

        public DbSet<VehicleMakeEntity> VehicleMakes { get; set; }
        public DbSet<VehicleModelEntity> VehicleModels { get; set; }
    }
}
