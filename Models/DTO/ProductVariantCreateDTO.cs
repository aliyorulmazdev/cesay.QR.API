using System.ComponentModel.DataAnnotations;

namespace cesay.QR.API.Models.DTO
{
    public class ProductVariantCreateDTO
    {
        [Required]
        public int ProductId { get; set; }
        public float Price { get; set; }
    }
}
