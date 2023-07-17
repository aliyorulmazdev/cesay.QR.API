using System.ComponentModel.DataAnnotations;

namespace cesay.QR.API.Models.Dto
{
    public class RestaurantDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public double Rate { get; set; }
    }
}
