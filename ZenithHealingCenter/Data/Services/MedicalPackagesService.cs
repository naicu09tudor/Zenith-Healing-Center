using Microsoft.EntityFrameworkCore;
using ZenithHealingCenter.Data.Base;
using ZenithHealingCenter.Data.ViewModels;
using ZenithHealingCenter.Models;

namespace ZenithHealingCenter.Data.Services
{
    public class MedicalPackagesService:EntityBaseRepository<MedicalPackage>, IMedicalPackagesService
    {
        private readonly AppDbContext _context;
        public MedicalPackagesService(AppDbContext context):base(context) 
        {
            _context = context;
        }

        public async Task AddNewMedicalPackageAsync(NewMedicalPackageVM data)
        {
            var newMedicakPackage = new MedicalPackage()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageFile = data.ImageFile,
                SpecializarePachet = data.SpecializarePachet,
                CabinetId = data.CabinetId,
                DoctorId = data.DoctorId
            };
            await _context.MedicalPackages.AddAsync(newMedicakPackage);
            await _context.SaveChangesAsync();
        }

        public async Task<MedicalPackage> GetMedicalPackagesByIdAsync(int id)
        {
            var medicalPackageDetails = await _context.MedicalPackages
                .Include(c => c.Cabinet)
                .Include(p => p.Doctor)

                .FirstOrDefaultAsync(n => n.Id == id);

            return medicalPackageDetails;
        }

        public async Task<NewMPVM> GetNewMPValues()
        {
            var response = new NewMPVM()
            {
                Doctors = await _context.Doctors.OrderBy(n => n.FullName).ToListAsync(),
                Cabinets = await _context.Cabinets.OrderBy(n => n.Name).ToListAsync()
            };
       

            return response;
        }

        public async Task UpdateMedicalPackageAsync(NewMedicalPackageVM data)
        {
            var DbMP = await _context.MedicalPackages.FirstOrDefaultAsync(n => n.Id == data.Id);
            if (DbMP != null)
            {
                
                DbMP.Name = data.Name;
                DbMP.Description = data.Description;
                DbMP.Price = data.Price;
                DbMP.ImageFile = data.ImageFile;
                DbMP.SpecializarePachet = data.SpecializarePachet;
                DbMP.CabinetId = data.CabinetId;
                DbMP.DoctorId = data.DoctorId;
                await _context.SaveChangesAsync();
            }
           
        }
    }
}
