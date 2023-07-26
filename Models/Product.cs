using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace cesay.QR.API.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public float Price { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }
        public int? RecipeId { get; set; }

        public ICollection<ProductMaterial>? ProductMaterials { get; set; }
        public Recipe? Recipe { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
