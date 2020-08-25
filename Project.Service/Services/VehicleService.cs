using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.Service.Contractors.Models;
using Project.Service.Contractors.Services;
using Project.Service.Entities;
using Project.Service.Filters;
using Project.Service.Models;

namespace Project.Service
{
    public class VehicleService : IVehicleService
    {

        #region DIProperties
        public VehicleContext Context { get; }
        public IMapper Mapper { get; }
        #endregion

        #region Constructor
        public VehicleService(VehicleContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        #endregion


        #region VehicleMake
        public async Task<IVehicleMake> AddVehicleMakeAsync(IVehicleMake vehicleMake)
        {
            if (vehicleMake != null)
            {
                var vehicleMakeEntity = Mapper.Map<VehicleMakeEntity>(vehicleMake);
                vehicleMakeEntity.Abrv = vehicleMakeEntity.Name.ToLower();
                await Context.VehicleMakes.AddAsync(vehicleMakeEntity);
                await Context.SaveChangesAsync();
            }
            return vehicleMake;
        }

        public async Task<IVehicleMake> DeleteVehicleMakeAsync(Guid id)
        {
            if (id != null)
            {
                VehicleMakeEntity vehicleMakeEntity = Context.VehicleMakes.Find(id);
                if (vehicleMakeEntity != null)
                {
                    Context.VehicleMakes.Remove(vehicleMakeEntity);
                    await Context.SaveChangesAsync();
                    var vehicleMake = Mapper.Map<IVehicleMake>(vehicleMakeEntity);
                    return vehicleMake;
                }
                return null;
            }
            return null;
        }

        public async Task<PaginationList<IVehicleMake>> GetVehicleMakesAsync(VehicleMakeFilter filter, int currentPage=1, string orderBy="")
        {
            var vehicleMakeEntities = HandleFilteringForVehicleMakes(filter);
            vehicleMakeEntities = HandleSortingForVehicleMakes(vehicleMakeEntities, orderBy);
            var vehicleMakes = Mapper.Map<IEnumerable<IVehicleMake>>(vehicleMakeEntities);
            var paginationList = new PaginationList<IVehicleMake>(vehicleMakes, currentPage);
            return await Task.FromResult(paginationList);
        }

        public async Task<IVehicleMake> GetVehicleMakeAsync(Guid id)
        {
            var vehicleMakeEntity = await Context.VehicleMakes.FindAsync(id);
            var vehicleMake = Mapper.Map<IVehicleMake>(vehicleMakeEntity);
            return vehicleMake;
        }

        #region Filtering and sorting vehicle makes
        private IQueryable<VehicleMakeEntity> HandleFilteringForVehicleMakes(VehicleMakeFilter filter)
        {
            IQueryable<VehicleMakeEntity> vehicleMakes;

            if (!String.IsNullOrEmpty(filter.Name))
            {
                vehicleMakes = Context.VehicleMakes.Where(vm => vm.Abrv.Contains(filter.Name.ToLower()));
            }
            else
            {
                vehicleMakes = Context.VehicleMakes;
            }

            return vehicleMakes;
        }

        private IQueryable<VehicleMakeEntity> HandleSortingForVehicleMakes(IQueryable<VehicleMakeEntity> entities, string orderBy)
        {

            if (orderBy == "date_created_desc")
            {
                entities = entities.OrderByDescending(vm => vm.DateCreated);
            }
            else if (orderBy == "date_created")
            {
                entities = entities.OrderBy(vm => vm.DateCreated);
            }
            else if (orderBy == "date_modified_desc")
            {
                entities = entities.OrderByDescending(vm => vm.DateModified);
            }
            else if (orderBy == "date_modified")
            {
                entities = entities.OrderBy(vm => vm.DateModified);
            }
            else if (orderBy == "alphabetically")
            {
                entities = entities.OrderBy(vm => vm.Name);
            }
            else if (orderBy == "alphabetically_desc")
            {
                entities = entities.OrderByDescending(vm => vm.Name);
            }
            return entities;
        }
        #endregion

        public async Task<IVehicleMake> UpdateVehicleMakeAsync(IVehicleMake vehicleMake)
        {
            if (vehicleMake != null)
            {
                var vehicleMakeEntity = Mapper.Map<VehicleMakeEntity>(vehicleMake);
                vehicleMakeEntity.DateModified = DateTime.UtcNow;
                var vehicleMakeEntityEntry = Context.VehicleMakes.Attach(vehicleMakeEntity);
                vehicleMakeEntityEntry.State = EntityState.Modified;
                await Context.SaveChangesAsync();
                return vehicleMake;
            }
            return null;
        }
        #endregion


        #region VehicleModel
        public async Task<IVehicleModel> AddVehicleModelAsync(IVehicleModel vehicleModel)
        {
            if (vehicleModel != null)
            {
                var vehicleModelEntity = Mapper.Map<VehicleModelEntity>(vehicleModel);
                vehicleModelEntity.Abrv = vehicleModelEntity.Name.ToLower();
                await Context.VehicleModels.AddAsync(vehicleModelEntity);
                await Context.SaveChangesAsync();
            }
            return vehicleModel;
        }

        public async Task<IVehicleModel> DeleteVehicleModelAsync(Guid id)
        {
            if (id != null)
            {
                VehicleModelEntity vehicleModelEntity = Context.VehicleModels.Find(id);
                if (vehicleModelEntity != null)
                {
                    Context.VehicleModels.Remove(vehicleModelEntity);
                    await Context.SaveChangesAsync();
                    var vehicleModel = Mapper.Map<VehicleModel>(vehicleModelEntity);
                    return vehicleModel;
                }
                return null;
            }
            return null;
        }

        public async Task<IVehicleModel> GetVehicleModelAsync(Guid id)
        {
            var vehicleModelEntity = await Context.VehicleModels.FindAsync(id);
            var vehicleModel = Mapper.Map<IVehicleModel>(vehicleModelEntity);
            return vehicleModel;
        }

        public async Task<PaginationList<IVehicleModel>> GetVehicleModelsAsync(VehicleModelFilter filter, int currentPage=1, string orderBy="")
        {
            var vehicleModelsEntities = HandleFilteringForVehicleModels(filter);
            vehicleModelsEntities = HandleSortingForVehicleModels(vehicleModelsEntities, orderBy);
            var vehicleModels = Mapper.Map<IEnumerable<IVehicleModel>>(vehicleModelsEntities);
            var paginationList = new PaginationList<IVehicleModel>(vehicleModels, currentPage);
            return await Task.FromResult(paginationList);
        }

        #region Filtering and sorting vehicle models
        private IQueryable<VehicleModelEntity> HandleFilteringForVehicleModels(VehicleModelFilter filter)
        {
            IQueryable<VehicleModelEntity> vehicleModels;

            if (filter.VehicleMakeId.HasValue)
            {
                if (!String.IsNullOrEmpty(filter.Name))
                    vehicleModels = Context.VehicleModels.Where(vm => vm.VehicleMakeId == filter.VehicleMakeId && vm.Abrv.Contains(filter.Name.ToLower()));
                else
                    vehicleModels = Context.VehicleModels.Where(vm => vm.VehicleMakeId == filter.VehicleMakeId);

            }
            else if (!String.IsNullOrEmpty(filter.Name))
            {
                vehicleModels = Context.VehicleModels.Where(vm => vm.Abrv.Contains(filter.Name.ToLower()));
            }
            else
            {
                vehicleModels = Context.VehicleModels;
            }

            return vehicleModels;
        }

        private IQueryable<VehicleModelEntity> HandleSortingForVehicleModels(IQueryable<VehicleModelEntity> entities, string orderBy)
        {

            if (orderBy == "date_created_desc")
            {
                entities = entities.OrderByDescending(vm => vm.DateCreated);
            }
            else if (orderBy == "date_created")
            {
                entities = entities.OrderBy(vm => vm.DateCreated);
            }
            else if (orderBy == "date_modified_desc")
            {
                entities = entities.OrderByDescending(vm => vm.DateModified);
            }
            else if (orderBy == "date_modified")
            {
                entities = entities.OrderBy(vm => vm.DateModified);
            }
            else if (orderBy == "alphabetically")
            {
                entities = entities.OrderBy(vm => vm.Name);
            }
            else if (orderBy == "alphabetically_desc")
            {
                entities = entities.OrderByDescending(vm => vm.Name);
            }
            return entities;
        }
        #endregion


        public async Task<IVehicleModel> UpdateVehicleModelAsync(IVehicleModel vehicleModel)
        {
            if (vehicleModel != null)
            {
                var vehicleModelEntity = Mapper.Map<VehicleModelEntity>(vehicleModel);
                vehicleModelEntity.DateModified = DateTime.UtcNow;
                var vehicleModelEntityEntry=Context.VehicleModels.Attach(vehicleModelEntity);
                vehicleModelEntityEntry.State = EntityState.Modified;
                await Context.SaveChangesAsync();
                return vehicleModel;
            }
            return null;
        }
        
        #endregion
    }
}
