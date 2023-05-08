using Microsoft.EntityFrameworkCore;
using ZenithHealingCenter.Models;

namespace ZenithHealingCenter.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Cabinet> Cabinets { get; set;}
        public DbSet<MedicalPackage> MedicalPackages { get; set; }

    }
}
