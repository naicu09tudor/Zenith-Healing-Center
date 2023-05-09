using System.ComponentModel.DataAnnotations;
using ZenithHealingCenter.Data.Enums;

namespace ZenithHealingCenter.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        public string FullName {  get; set; }

        public Specializare SpecializareDoctor { get; set; }

        public string ImageURL { get; set; }

        // Relationships
        public List<MedicalPackage> MedicalPackages { get; set; }
    }
}
