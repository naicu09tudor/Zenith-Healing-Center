using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZenithHealingCenter.Data.Base;
using ZenithHealingCenter.Data.Enums;

namespace ZenithHealingCenter.Models
{
    public class MedicalPackage:IEntityBase
    {
        [Key] public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string ImageFile { get; set; }

        public Specializare SpecializarePachet { get; set; }

        //Cabinets
        public int CabinetId { get; set; }
        [ForeignKey("CabinetId")]
        public Cabinet Cabinet { get; set; }

        //Doctors
        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }

    }
}
