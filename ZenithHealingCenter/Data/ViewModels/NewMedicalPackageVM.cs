using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZenithHealingCenter.Data.Base;
using ZenithHealingCenter.Data.Enums;

namespace ZenithHealingCenter.Models
{
    public class NewMedicalPackageVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Nume")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Nameis required")]
        [Display(Name = "Descriere")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Priceis required")]
        [Display(Name = "Pret")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Image is required")]
        [Display(Name = "Imagine")]

        public string ImageFile { get; set; }
        [Required(ErrorMessage = "Specializare is required")]
        [Display(Name = "Specializare")]
        public Specializare SpecializarePachet { get; set; }

        [Required(ErrorMessage = "Cabinet is required")]
        [Display(Name = "Select a cabinet")]
        public int CabinetId { get; set; }


        [Required(ErrorMessage = "Doctor is required")]
        [Display(Name = "Select a doctor")]
        public int DoctorId { get; set; }
 

    }
}
