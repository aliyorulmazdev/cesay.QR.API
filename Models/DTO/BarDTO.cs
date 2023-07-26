using System.ComponentModel.DataAnnotations;

namespace cesay.QR.API.Models.DTO
{
    public class BarDTO
    {
        public int Id { get; set; }
        [Required]
        public int RestaurantId { get; set; }
    }
}
