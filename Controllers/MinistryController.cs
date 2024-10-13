using GarageManagement.Data;
using GarageManagement.Models.Entities;
using GarageManagement.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GarageManagement.Controllers
{
    
    public class MinistryController : Controller
    {
        private readonly ApplicationDbcontext _context;
        public MinistryController(ApplicationDbcontext _context)
        {
            this._context = _context;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddMinistryViewModel viewModel) 
        {
            var ministry = new Ministry
            {
                Name = viewModel.Name,
            };
            await _context.Ministry.AddAsync(ministry);
            await _context.SaveChangesAsync();
            return RedirectToAction("List", "Ministry");
        }

        [HttpGet]

        public async Task<IActionResult> List()
        {
            var ministry = await _context.Ministry.ToListAsync();
            return View(ministry);
        }

        [HttpGet]

        public async Task<IActionResult> Edit(Guid id)
        {
          var foundministry =  await _context.Ministry.FindAsync(id);
            return View(foundministry);
        }

        [HttpPost]

        public async Task<IActionResult> Edit (Ministry viewModel)
        {
           var ministry = await _context.Ministry.FindAsync (viewModel.MinistryId);
            if(ministry is not null)
            {
                ministry.Name = viewModel.Name;

                await _context.SaveChangesAsync();
            }

            return RedirectToAction("List", "Ministry");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Ministry viewModel)
        {
            var ministry = await _context.Ministry 
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.MinistryId == viewModel.MinistryId);
            if (ministry is not null)
            {
                _context.Ministry.Remove(viewModel);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("List", "Ministry");
        }
    }
}
