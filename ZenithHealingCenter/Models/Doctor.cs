using System.ComponentModel.DataAnnotations;
using ZenithHealingCenter.Data.Enums;

namespace ZenithHealingCenter.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "FullName")]
        public string FullName {  get; set; }

        [Display(Name = "Specializare Doctor")]
        public Specializare SpecializareDoctor { get; set; }

        [Display(Name = "Poza de Profil")]
        public string ImageURL { get; set; }

        // Relationships
        public List<MedicalPackage> MedicalPackages { get; set; }
    }
}
