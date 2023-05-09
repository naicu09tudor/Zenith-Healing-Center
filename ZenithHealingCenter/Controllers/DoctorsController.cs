using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZenithHealingCenter.Data;

namespace ZenithHealingCenter.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly AppDbContext _context;
        public DoctorsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var allDoctors = _context.Doctors.ToList();
            return View();
        }
    }
}
