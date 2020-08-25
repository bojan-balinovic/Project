using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service.Contractors.Models
{
    public interface IVehicleModel:IBaseModel
    {   
        string Name { get; set; }
        string Abrv { get; set; }
        Guid VehicleMakeId { get; set; }
    }
}
