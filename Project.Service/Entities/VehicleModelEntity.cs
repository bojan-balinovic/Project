using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service.Entities
{
    public class VehicleModelEntity : BaseEntity
    {
        public VehicleMakeEntity Make { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public Guid VehicleMakeId { get; set; }
    }
}
