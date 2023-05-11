using System.ComponentModel.DataAnnotations;

namespace ZenithHealingCenter.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        
        public MedicalPackage MedicalPackage { get; set; }
        public int Amount { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
