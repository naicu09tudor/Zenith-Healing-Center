using ZenithHealingCenter.Data.Base;
using ZenithHealingCenter.Models;

namespace ZenithHealingCenter.Data.Services
{
    public class CabinetsService:EntityBaseRepository<Cabinet>, ICabinetsService
    {
        public CabinetsService(AppDbContext context):base(context)
        {
            
        }
    }
}
