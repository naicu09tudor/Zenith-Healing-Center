using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZenithHealingCenter.Data;
using ZenithHealingCenter.Data.Services;
using ZenithHealingCenter.Data.ViewModels;
using ZenithHealingCenter.Models;

namespace ZenithHealingCenter.Controllers
{
    public class MedicalPackagesController : Controller
    {
        private readonly IMedicalPackagesService _service;
        public MedicalPackagesController(IMedicalPackagesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allMedicalPackages = await _service.GetAllAsync(n => n.Cabinet);
            return View(allMedicalPackages);
        }
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMedicalPackages = await _service.GetAllAsync(n => n.Cabinet);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filterResult = allMedicalPackages.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                return View("Index", filterResult);
            }
            return View("Index", allMedicalPackages);
        }

        //Get: MoviesDetails
        public async Task<IActionResult> Details(int id)
        {
            var MedicalPackageDetail = await _service.GetMedicalPackagesByIdAsync(id);
            return View(MedicalPackageDetail);
        }

        //get: movies/create
        public async Task<IActionResult> Create()
        {
            var MPDropdownsData = await _service.GetNewMPValues();

            ViewBag.Cabinets = new SelectList(MPDropdownsData.Cabinets, "Id", "Name");
         
            ViewBag.Doctors = new SelectList(MPDropdownsData.Doctors, "Id", "FullName");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewMedicalPackageVM MP)
        {
            var MPDropdownsData = await _service.GetNewMPValues();
            if(!ModelState.IsValid)
            {
                ViewBag.Cabinets = new SelectList(MPDropdownsData.Cabinets, "Id", "Name");

                ViewBag.Doctors = new SelectList(MPDropdownsData.Doctors, "Id", "FullName");
                return View(MP);
            }
         

            
            await _service.AddNewMedicalPackageAsync(MP);
            return RedirectToAction(nameof(Index));
        }

        //Edit
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetMedicalPackagesByIdAsync(id);
            if (movieDetails == null) return View("NotFound");

            var response = new NewMedicalPackageVM()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                ImageFile = movieDetails.ImageFile,
                SpecializarePachet = movieDetails.SpecializarePachet,
                CabinetId = movieDetails.CabinetId,
                DoctorId = movieDetails.DoctorId,
               
            };

            var MPDropdownsData = await _service.GetNewMPValues();
            ViewBag.Cabinets = new SelectList(MPDropdownsData.Cabinets, "Id", "Name");

            ViewBag.Doctors = new SelectList(MPDropdownsData.Doctors, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMedicalPackageVM MP)
        {
            if (id != MP.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var MPDropdownsData = await _service.GetNewMPValues();

                ViewBag.Cabinets = new SelectList(MPDropdownsData.Cabinets, "Id", "Name");

                ViewBag.Doctors = new SelectList(MPDropdownsData.Doctors, "Id", "FullName");

                return View(MP);
            }

            await _service.UpdateMedicalPackageAsync(MP);
            return RedirectToAction(nameof(Index));
        }


    }
}
