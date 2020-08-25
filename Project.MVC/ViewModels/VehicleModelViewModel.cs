using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Project.Service.Filters.VehicleModelFilter;

namespace Project.MVC.ViewModels
{
    public class VehicleModelViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid VehicleMakeId { get; set; }
    }
}
