using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace cesay.QR.API.Models
{
    public class ProductMaterial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public bool defaultSelected { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public Product Product { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
