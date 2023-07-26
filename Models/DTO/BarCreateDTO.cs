using System.ComponentModel.DataAnnotations;

namespace cesay.QR.API.Models.DTO
{
    public class BarCreateDTO
    {
        [Required]
        public int RestaurantId { get; set; }
    }
}
