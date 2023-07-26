using System.ComponentModel.DataAnnotations;

namespace cesay.QR.API.Models.DTO
{
    public class KitchenUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int RestaurantId { get; set; }
    }
}
