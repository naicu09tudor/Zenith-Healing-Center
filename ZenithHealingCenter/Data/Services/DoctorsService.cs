using Microsoft.EntityFrameworkCore;
using ZenithHealingCenter.Models;

namespace ZenithHealingCenter.Data.Services
{
    public class DoctorsService : IDoctorsService
    {

        private readonly AppDbContext _context;
        public DoctorsService(AppDbContext context)
        {
            _context = context;
        }



        public void Add(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Doctor>> GetAll()
        {
            var result = await _context.Doctors.ToListAsync();
            return result;
        }

        public Doctor GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Doctor Update(int id, Doctor newDoctor)
        {
            throw new NotImplementedException();
        }
    }
}
