using System.ComponentModel.DataAnnotations;
using ZenithHealingCenter.Data.Base;

namespace ZenithHealingCenter.Models
{
    public class Cabinet:IEntityBase
    {
        [Key] 
        public int Id { get; set; }

        [Display(Name = "Nume Cabinet")]
        [Required(ErrorMessage = "Nume required")]
        public string Name { get; set; }

        [Display(Name = "Descriere Cabinet")]
        [Required(ErrorMessage = "Descriere required")]
        public string Description { get; set; }

        // Relationships
        public List<MedicalPackage> MedicalPackages { get; set; }

    }
}
