using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service.Contractors.Models
{
    public interface IVehicleMake:IBaseModel
    {
        string Name { get; set; }
        string Abrv { get; set; }
        ICollection<IVehicleModel> VehicleModels { get; set; }
    }
}
