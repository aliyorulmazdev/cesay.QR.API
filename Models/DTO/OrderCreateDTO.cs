using System.ComponentModel.DataAnnotations;

namespace cesay.QR.API.Models.DTO
{
    public class OrderCreateDTO
    {
        public float Price { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }

        [Required]
        public int RestaurantId { get; set; }
        [Required]
        public int TableId { get; set; }
        [Required]
        public int ProductVariantId { get; set; }
    }
}
