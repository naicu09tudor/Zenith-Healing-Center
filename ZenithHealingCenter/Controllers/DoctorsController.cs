using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZenithHealingCenter.Data;
using ZenithHealingCenter.Data.Services;
using ZenithHealingCenter.Models;

namespace ZenithHealingCenter.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IDoctorsService _service;
        public DoctorsController(IDoctorsService service)
        {
            _service = service;
        }

        public async Task< IActionResult>Index()
        {
            IEnumerable<Doctor> allDoctors = await _service.GetAllAsync();
            return View(allDoctors);
        }
        //get actors/create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ImageURL,SpecializareDoctor")]Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return View(doctor);
            }
            await _service.AddAsync(doctor);
            return RedirectToAction(nameof(Index));
        }
        //Get: Actors/Detail/1
        public async Task<IActionResult> Details(int id)
        {
            Doctor DoctorDetails = await _service.GetByIdAsync(id);

            if (DoctorDetails == null) return View("NotFound");
            return View(DoctorDetails);
        }

        //Edit
        public async Task<IActionResult> Edit(int id)
        {

            Doctor DoctorDetails = await _service.GetByIdAsync(id);

            if (DoctorDetails == null) return View("NotFound");
            return View(DoctorDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,SpecializareDoctor,ImageURL")] Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return View(doctor);
            }

            await _service.UpdateAsync(id,doctor);
            return RedirectToAction(nameof(Index));
        }
        //dELETE/1
        public async Task<IActionResult> Delete(int id)
        {

            Doctor DoctorDetails = await _service.GetByIdAsync(id);

            if (DoctorDetails == null) return View("NotFound");
            return View(DoctorDetails);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Doctor DoctorDetails = await _service.GetByIdAsync(id);

            if (DoctorDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
