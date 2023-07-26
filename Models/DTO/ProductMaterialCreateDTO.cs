﻿using System.ComponentModel.DataAnnotations;

namespace cesay.QR.API.Models.DTO
{
    public class ProductMaterialCreateDTO
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public int RestaurantId { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}
