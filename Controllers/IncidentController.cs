using GarageManagement.Data;
using GarageManagement.Models.Entities;
using GarageManagement.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GarageManagement.Controllers
{
    [Authorize]
    public class IncidentController : Controller
    {
        
        private readonly ApplicationDbcontext _context;
        public IncidentController(ApplicationDbcontext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Add()
        {
            var viewModel = new AddIncidentViewModel
            {
                Vehicles = _context.Vehicle.ToList(),

            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddIncidentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Vehicles = _context.Vehicle.ToList();
               
               // return View(viewModel);
            }
            var incident = new Incident
            {
                Description = viewModel.Description,
                VehicleId = viewModel.VehicleId,
                Status = viewModel.Status,
                DateReported = viewModel.DateReported,
                SeverityLevel = viewModel.SeverityLevel,
                

               
            };

            await _context.Incidents.AddAsync(incident);
            await _context.SaveChangesAsync();

            return RedirectToAction("List", "Incident");
        }

        [HttpGet]

        public async Task< IActionResult> List() { 
        var incident = await _context.Incidents.Include(x => x.Vehicle).ToListAsync();
            return View(incident);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var incident = await _context.Incidents.FindAsync(id);
            if (incident == null)
            {
                return NotFound();
            }

            var viewModel = new AddIncidentViewModel
            {
                IncidentId = incident.IncidentId,
                Description = incident.Description,
                VehicleId = incident.VehicleId,
                Status = incident.Status,
                DateReported = incident.DateReported,
                SeverityLevel = incident.SeverityLevel,
                Vehicles = await _context.Vehicle.ToListAsync()
            };

            return View(viewModel);
        }


        [HttpPost]

        public async Task<IActionResult> Edit(Incident viewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Vehicles = _context.Vehicle.ToList();
                // return View(viewModel);
            }


            var incident = await _context.Incidents.FindAsync(viewModel.IncidentId);

            if (incident is not null)
            {
                incident.DateReported = viewModel.DateReported;
                incident.Description = viewModel.Description;
                incident.Vehicle = viewModel.Vehicle;
                incident.SeverityLevel = viewModel.SeverityLevel;
                incident.Status = viewModel.Status;

                await _context.SaveChangesAsync();
            }
            if (incident is null) { }
            return RedirectToAction("List", "Incident");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Incident viewModel)
        {
            var incident = await _context.Incidents
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.IncidentId == viewModel.IncidentId);
            if (incident is not null)
            {
                _context.Incidents.Remove(viewModel);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("List", "Incidents");
        }


    }
}
