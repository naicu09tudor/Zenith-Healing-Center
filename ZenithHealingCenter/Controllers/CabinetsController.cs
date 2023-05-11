using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZenithHealingCenter.Data;
using ZenithHealingCenter.Data.Services;
using ZenithHealingCenter.Data.Static;
using ZenithHealingCenter.Models;

namespace ZenithHealingCenter.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class CabinetsController : Controller
    {

        private readonly ICabinetsService _service;
        public CabinetsController(ICabinetsService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allCabinets = await _service.GetAllAsync();
            return View(allCabinets);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Description")] Cabinet cabinet)
        {
            if (!ModelState.IsValid)
            {
                return View(cabinet);
            }
            await _service.AddAsync(cabinet);
            return RedirectToAction(nameof(Index));
        }

        //Get: Cabinet/Detail/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            Cabinet CabinetDetails = await _service.GetByIdAsync(id);

            if (CabinetDetails == null) return View("NotFound");
            return View(CabinetDetails);

        }

        //Edit
        public async Task<IActionResult> Edit(int id)
        {

            Cabinet CabinetDetails = await _service.GetByIdAsync(id);

            if (CabinetDetails == null) return View("NotFound");
            return View(CabinetDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Cabinet cabinet)
        {
            if (!ModelState.IsValid)
            {
                return View(cabinet);
            }

            await _service.UpdateAsync(id, cabinet);
            return RedirectToAction(nameof(Index));
        }

        //Delete
        public async Task<IActionResult> Delete(int id)
        {

            Cabinet CabinetDetails = await _service.GetByIdAsync(id);

            if (CabinetDetails == null) return View("NotFound");
            return View(CabinetDetails);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Cabinet CabinetDetails = await _service.GetByIdAsync(id);

            if (CabinetDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
