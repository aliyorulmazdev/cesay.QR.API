using System.ComponentModel.DataAnnotations;

namespace cesay.QR.API.Models.DTO
{
    public class ProductVariantDTO
    {
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        public float Price { get; set; }
    }
}
