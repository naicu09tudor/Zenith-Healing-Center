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



        public async Task AddAsync(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Doctors.FirstOrDefaultAsync(n => n.Id == id);
#pragma warning disable CS8604 // Possible null reference argument.
            _context.Doctors.Remove(result);
#pragma warning restore CS8604 // Possible null reference argument.
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            var result = await _context.Doctors.ToListAsync();
            return result;
        }

        public async Task<Doctor> GetByIdAsync(int id)
        {
            var result = await _context.Doctors.FirstOrDefaultAsync(n => n.Id == id);
#pragma warning disable CS8603 // Possible null reference return.
            return result;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<Doctor> UpdateAsync(int id, Doctor newDoctor)
        {
            _context.Update(newDoctor);
            await _context.SaveChangesAsync();
            return newDoctor;
        }
    }
}
