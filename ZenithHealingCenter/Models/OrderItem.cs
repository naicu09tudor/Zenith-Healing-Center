using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZenithHealingCenter.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; } 

        public double Price { get;set; }

        // Relations
        public int MedicalPackageId { get; set; }
        [ForeignKey("MedicalPackageId")]
        public MedicalPackage MedicalPackage { get; set; }


        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order{ get; set; }
    }
}
