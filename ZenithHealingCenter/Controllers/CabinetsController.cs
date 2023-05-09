using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZenithHealingCenter.Data;

namespace ZenithHealingCenter.Controllers
{
    public class CabinetsController : Controller
    {

        private readonly AppDbContext _context;
        public CabinetsController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allCabinets = await _context.Cabinets.ToListAsync();
            return View();
        }
    }
}
