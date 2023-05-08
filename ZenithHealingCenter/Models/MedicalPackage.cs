using System.ComponentModel.DataAnnotations;
using ZenithHealingCenter.Data.Enums;

namespace ZenithHealingCenter.Models
{
    public class MedicalPackages
    {
        [Key] public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string ImageFile { get; set; }

        public Specializare SpecializarePachet { get; set; }

    }
}
