using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.MVC.ViewModels;
using Project.Service.Contractors.Models;
using Project.Service.Contractors.Services;
using Project.Service.Filters;
using Project.Service.Models;

namespace Project.MVC.Controllers
{
    public class VehicleModelController : Controller
    {
        public IVehicleService Service { get; }
        public IMapper Mapper { get; }

        public VehicleModelController(IVehicleService service, IMapper mapper)
        {
            Service = service;
            Mapper = mapper;
        }

        // GET: VehicleModel
        public async Task<ActionResult> Index(Guid id, string orderBy, int currentPage, string searchQuery="")
        {
            var vehicleMakeId = id;
            if (vehicleMakeId != null)
            {
                var filter = new VehicleModelFilter() {VehicleMakeId=vehicleMakeId, Name=searchQuery};
                var vehicleModelsPaginationList = await Service.GetVehicleModelsAsync(filter, currentPage, orderBy);
                var mapped = Mapper.Map<IEnumerable<VehicleModelViewModel>>(vehicleModelsPaginationList.Items);

                ViewBag.TotalPages = vehicleModelsPaginationList.TotalPages;
                ViewBag.VehicleMakeId = vehicleMakeId.ToString();
                return View(mapped);
            }
            return RedirectToAction(nameof(VehicleMakeController.Index));
        }

        // GET: VehicleModel/Create
        public async Task<ActionResult> Create(Guid id)
        {
            var model = new VehicleModelViewModel() { VehicleMakeId = id };
            return await Task.FromResult(View(model));
        }

        // POST: VehicleModel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(VehicleModelViewModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                var mappedVehicleModel = Mapper.Map<VehicleModel>(vehicleModel);
                await Service.AddVehicleModelAsync(mappedVehicleModel);
                return RedirectToAction(nameof(Index), new { id=vehicleModel.VehicleMakeId });
            }
            return View();
        }

        // GET: VehicleModel/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var vehicleModel = await Service.GetVehicleModelAsync(id);
            if (vehicleModel != null)
            {
                var mapped = Mapper.Map<VehicleModelViewModel>(vehicleModel);
                return View(mapped);
            }
            return View();
        }

        // POST: VehicleModel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(VehicleModelViewModel vehicleModelChanges)
        {
            if (ModelState.IsValid)
            {
                var mappedVehicleModelChanges = Mapper.Map<IVehicleModel>(vehicleModelChanges);
                await Service.UpdateVehicleModelAsync(mappedVehicleModelChanges);
            }
            return RedirectToAction(nameof(Index),new { id=vehicleModelChanges.VehicleMakeId});
        }

        // POST: VehicleModel/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id)
        {
            var vehicleModel=await Service.DeleteVehicleModelAsync(id);
            return RedirectToAction(nameof(Index), new { id=vehicleModel.VehicleMakeId });

        }
    }
}