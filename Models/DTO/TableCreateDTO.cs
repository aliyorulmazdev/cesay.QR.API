using System.ComponentModel.DataAnnotations;

namespace cesay.QR.API.Models.DTO
{
    public class TableCreateDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public int RestaurantId { get; set; }
    }
}
