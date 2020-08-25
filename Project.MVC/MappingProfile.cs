using AutoMapper;
using Project.MVC.Models;
using Project.MVC.ViewModels;
using Project.Service.Contractors.Models;
using Project.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.MVC
{
    public class MappingProfile:Profile
    {

        public MappingProfile()
        {

            CreateMap<IVehicleMake, VehicleMake>().ReverseMap();
            CreateMap<VehicleMakeViewModel, IVehicleMake>().ReverseMap();
            CreateMap<VehicleMakeViewModel, VehicleMake>().ReverseMap();

            CreateMap<IVehicleModel, VehicleModel>().ReverseMap();
            CreateMap<VehicleModelViewModel, IVehicleModel>().ReverseMap();
            CreateMap<VehicleModelViewModel, VehicleModel>().ReverseMap();
        }

    }
}
