using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZenithHealingCenter.Data;

namespace ZenithHealingCenter.Controllers
{
    public class MedicalPackagesController : Controller
    {
        private readonly AppDbContext _context;
        public MedicalPackagesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allMedicalPackages = await _context.MedicalPackages.ToListAsync();
            return View(allMedicalPackages);
        }
    }
}
