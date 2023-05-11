﻿using System.ComponentModel.DataAnnotations;

namespace ZenithHealingCenter.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }

        // Relationship
        public List<OrderItem> OrderItems { get; set; }

    }
}
