using System.ComponentModel.DataAnnotations;

namespace ZenithHealingCenter.Models
{
    public class Cabinet
    {
        [Key] public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        // Relationships
        public List<MedicalPackage> MedicalPackages { get; set; }

    }
}
