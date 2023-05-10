using Microsoft.EntityFrameworkCore;
using ZenithHealingCenter.Data.Base;
using ZenithHealingCenter.Models;

namespace ZenithHealingCenter.Data.Services
{
    public class DoctorsService : EntityBaseRepository<Doctor>, IDoctorsService
    {

        private readonly AppDbContext _context;
        public DoctorsService(AppDbContext context) : base(context)
        {
            
        }



        
    }
}
