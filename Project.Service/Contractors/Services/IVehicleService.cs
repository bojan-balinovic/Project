using Project.Service.Contractors.Models;
using Project.Service.Filters;
using Project.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Contractors.Services
{
    public interface IVehicleService
    {

        #region VehicleMake
        /// <summary>
        /// Returns vehicle make by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IVehicleMake> GetVehicleMakeAsync(Guid id);
        Task<PaginationList<IVehicleMake>> GetVehicleMakesAsync(VehicleMakeFilter filter, int currentPage, string orderBy);
        Task<IVehicleMake> UpdateVehicleMakeAsync(IVehicleMake IVehicleMake);
        Task<IVehicleMake> AddVehicleMakeAsync(IVehicleMake IVehicleMake);
        Task<IVehicleMake> DeleteVehicleMakeAsync(Guid id);
        #endregion

        #region VehicleModel
        Task<IVehicleModel> GetVehicleModelAsync(Guid id);
        Task<PaginationList<IVehicleModel>> GetVehicleModelsAsync(VehicleModelFilter filter, int currentPage, string orderBy);
        Task<IVehicleModel> UpdateVehicleModelAsync(IVehicleModel IVehicleMake);
        Task<IVehicleModel> AddVehicleModelAsync(IVehicleModel IVehicleMake);
        Task<IVehicleModel> DeleteVehicleModelAsync(Guid id);
        #endregion

    }
}
