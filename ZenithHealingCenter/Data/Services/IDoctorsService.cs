using ZenithHealingCenter.Models;

namespace ZenithHealingCenter.Data.Services
{
    public interface IDoctorsService
    {
        Task<IEnumerable<Doctor>> GetAll();
        Doctor GetById(int id);
        void Add(Doctor doctor);
        Doctor Update(int id, Doctor newDoctor);

        void Delete(int id);
    }
}
