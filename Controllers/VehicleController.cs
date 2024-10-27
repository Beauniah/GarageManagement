using GarageManagement.Data;
using GarageManagement.Models.Entities;
using GarageManagement.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManagement.Controllers
{
    public class VehicleController : Controller
    {
        private readonly ApplicationDbcontext _context;

        public VehicleController(ApplicationDbcontext _context)
        {
            this._context = _context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var ministries = _context.Ministry.ToList();
            if (!ministries.Any())
            {
                // Log or inspect that ministries list is empty
                Console.WriteLine("No ministries found in the database.");
            }
            var viewModel = new AddVehicleViewModel
            {
                Ministries = ministries
            };
            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Add(AddVehicleViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // Log all validation errors for debugging
                foreach (var modelStateKey in ModelState.Keys)
                {
                    var modelStateVal = ModelState[modelStateKey];
                    foreach (var error in modelStateVal.Errors)
                    {
                        Console.WriteLine($"Key: {modelStateKey}, Error: {error.ErrorMessage}");
                    }
                }

                // Repopulate Ministries and return view
                viewModel.Ministries = _context.Ministry.ToList();
                return View(viewModel);
            }

            var vehicle = new Vehicle
            {
                Make = viewModel.Make,
                Year = viewModel.Year,
                DateAquired = viewModel.DateAquired,
                Model = viewModel.Model,
                MinistryId = viewModel.MinistryId,
            };

            await _context.Vehicle.AddAsync(vehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction("List");
        }


        [HttpGet]
        public async Task<IActionResult> List()
        {
            var vehicles = await _context.Vehicle.Include(v => v.Ministry).ToListAsync();
            return View(vehicles);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var vehicle = await _context.Vehicle.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            var viewModel = new AddVehicleViewModel
            {
                VehicleId = vehicle.VehicleId,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Year = vehicle.Year,
                DateAquired = vehicle.DateAquired,
                MinistryId = vehicle.MinistryId,
                Ministries = await _context.Ministry.ToListAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddVehicleViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Ministries = await _context.Ministry.ToListAsync();
                return View(viewModel);
            }

            var vehicle = await _context.Vehicle.FindAsync(viewModel.VehicleId);
            if (vehicle != null)
            {
                vehicle.Model = viewModel.Model;
                vehicle.Make = viewModel.Make;
                vehicle.Year = viewModel.Year;
                vehicle.DateAquired = viewModel.DateAquired;
                vehicle.MinistryId = viewModel.MinistryId;

                await _context.SaveChangesAsync();
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var vehicle = await _context.Vehicle.FindAsync(id);
            if (vehicle != null)
            {
                _context.Vehicle.Remove(vehicle);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("List");
        }
    }
}
