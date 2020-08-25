using AutoMapper;
using Project.Service.Contractors.Models;
using Project.Service.Entities;
using Project.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            #region VehicleMake mapping
            CreateMap<IVehicleMake, VehicleMakeEntity>().ReverseMap();

            CreateMap<VehicleMake, VehicleMakeEntity>().ReverseMap();
            #endregion

            #region VehicleModel mapping
            CreateMap<IVehicleModel, VehicleModelEntity>().ReverseMap();

            CreateMap<VehicleModel, VehicleModelEntity>().ReverseMap();
            #endregion

        }
    }
}
