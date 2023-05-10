using ZenithHealingCenter.Models;

namespace ZenithHealingCenter.Data.Services
{
    public interface IDoctorsService
    {
        Task<IEnumerable<Doctor>> GetAllAsync();
        Task<Doctor> GetByIdAsync(int id);
        Task AddAsync(Doctor doctor);
        Task<Doctor> UpdateAsync(int id, Doctor newDoctor);

        Task DeleteAsync(int id);
    }
}
