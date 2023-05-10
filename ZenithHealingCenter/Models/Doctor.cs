using System.ComponentModel.DataAnnotations;
using ZenithHealingCenter.Data.Enums;

namespace ZenithHealingCenter.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nume Doctor")]
        [Required(ErrorMessage = "Nume required")]

        public string FullName {  get; set; }

        [Display(Name = "Specializare Doctor")]
        [Required(ErrorMessage = "Specializare required")]

        public Specializare SpecializareDoctor { get; set; }

        [Display(Name = "Poza de Profil")]
        [Required(ErrorMessage ="Picture required")]
        public string ImageURL { get; set; }

        // Relationships
        public List<MedicalPackage> MedicalPackages { get; set; }
    }
}
