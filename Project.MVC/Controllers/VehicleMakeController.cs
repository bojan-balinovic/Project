using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.MVC.Models;
using Project.MVC.ViewModels;
using Project.Service;
using Project.Service.Contractors.Models;
using Project.Service.Contractors.Services;
using Project.Service.Filters;
using Project.Service.Models;

namespace Project.MVC.Controllers
{
    public class VehicleMakeController : Controller
    {
        private IVehicleService Service { get; }
        public IMapper Mapper { get; }

        public VehicleMakeController(IVehicleService service, IMapper mapper)
        {
            Service = service;
            Mapper = mapper;
        }

        // GET: VehicleMake
        public async Task<ActionResult> Index(string orderBy, int currentPage=1, string searchQuery="")
        {
            var filter = new VehicleMakeFilter() { Name=searchQuery };
            var vehicleMakesPaginationList = await Service.GetVehicleMakesAsync(filter, currentPage, orderBy);
            var mapped = Mapper.Map<IEnumerable<VehicleMakeViewModel>>(vehicleMakesPaginationList.Items);
            ViewBag.TotalPages = vehicleMakesPaginationList.TotalPages;
            ViewBag.CurrentPage = currentPage;
            ViewBag.bla = searchQuery;
            return View(mapped);
        }

        // GET: VehicleMake/Create
        public async Task<ActionResult> Create()
        {
            return await Task.FromResult(View());
        }

        // POST: VehicleMake/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(VehicleMakeViewModel vehicleMake)
        {
            if (ModelState.IsValid)
            {
                var mappedVehicleMake = Mapper.Map<VehicleMake>(vehicleMake);
                await Service.AddVehicleMakeAsync(mappedVehicleMake);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: VehicleMake/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var vehicleMake = await Service.GetVehicleMakeAsync(id);
            if (vehicleMake != null)
            {
                var mapped = Mapper.Map<VehicleMakeViewModel>(vehicleMake);
                return View(mapped);
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: VehicleMake/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(VehicleMakeViewModel vehicleMakeChanges)
        {
            if (ModelState.IsValid)
            {
                var mappedVehicleMakeChanges = Mapper.Map<IVehicleMake>(vehicleMakeChanges);
                await Service.UpdateVehicleMakeAsync(mappedVehicleMakeChanges);
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: VehicleMake/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id)
        {
            await Service.DeleteVehicleMakeAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}