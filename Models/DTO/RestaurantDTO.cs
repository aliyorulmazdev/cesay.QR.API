using System.ComponentModel.DataAnnotations;

namespace cesay.QR.API.Models.DTO
{
    public class RestaurantDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string LogoUrl { get; set; }
        [Required]
        public double Rate { get; set; }
        [Required]
        public string Secret { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
