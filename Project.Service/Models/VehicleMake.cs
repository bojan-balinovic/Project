using Project.Service.Contractors.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service.Models
{
    public class VehicleMake : BaseModel, IVehicleMake
    {
        public VehicleMake()
        {
            DateCreated = DateTime.UtcNow;
            DateModified = DateTime.UtcNow;
        }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public ICollection<IVehicleModel> VehicleModels { get; set; }
    }
}
