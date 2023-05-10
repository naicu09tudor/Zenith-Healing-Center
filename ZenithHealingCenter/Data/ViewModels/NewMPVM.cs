using ZenithHealingCenter.Models;

namespace ZenithHealingCenter.Data.ViewModels
{
    public class NewMPVM
    {
        public NewMPVM()
        {
            Cabinets = new List<Cabinet>();
            Doctors = new List<Doctor>();

        }
        public List<Cabinet> Cabinets { get; set; }
        public List<Doctor> Doctors { get; set; }

    }
}
