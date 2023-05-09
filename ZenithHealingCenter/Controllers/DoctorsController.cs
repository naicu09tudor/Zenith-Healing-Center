using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZenithHealingCenter.Data;
using ZenithHealingCenter.Data.Services;

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
            var allDoctors = await _service.GetAll();
            return View(allDoctors);
        }
    }
}
