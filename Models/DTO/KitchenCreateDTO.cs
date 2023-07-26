using System.ComponentModel.DataAnnotations;

namespace cesay.QR.API.Models.DTO
{
    public class KitchenCreateDTO
    {
        [Required]
        public int RestaurantId { get; set; }
    }
}
