using ZenithHealingCenter.Data.Base;
using ZenithHealingCenter.Data.ViewModels;
using ZenithHealingCenter.Models;

namespace ZenithHealingCenter.Data.Services
{
    public interface IMedicalPackagesService:IEntityBaseRepository<MedicalPackage>
    {
        Task<MedicalPackage> GetMedicalPackagesByIdAsync(int id);
        Task<NewMPVM> GetNewMPValues();
        Task AddNewMedicalPackageAsync(NewMedicalPackageVM data);
        Task UpdateMedicalPackageAsync(NewMedicalPackageVM data);
    }
}
