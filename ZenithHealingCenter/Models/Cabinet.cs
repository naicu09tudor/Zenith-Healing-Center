using System.ComponentModel.DataAnnotations;

namespace ZenithHealingCenter.Models
{
    public class Cabinet
    {
        [Key] public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        // Relationships
        public List<MedicalPackage> MedicalPackages { get; set; }

    }
}
