using System.ComponentModel.DataAnnotations;

namespace cesay.QR.API.Models.DTO
{
    public class RecipeCreateDTO
    {
        public string Description { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int RestaurantId { get; set; }
    }
}
