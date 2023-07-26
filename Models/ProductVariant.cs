using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace cesay.QR.API.Models
{
    public class ProductVariant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        // Define a private field to store the Price value
        private float _price;

        // This property won't be mapped to the database
        [NotMapped]
        public float Price
        {
            get
            {
                // Calculate the sum of product's price and ProductMaterials' prices
                float materialPricesSum = ProductMaterials?.Sum(pm => pm.Price) ?? 0;
                return Product.Price + materialPricesSum;
            }
            set
            {
                // You can choose to add validation logic if needed
                _price = value;
            }
        }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public ICollection<ProductMaterial>? ProductMaterials { get; set; }
        public Product Product { get; set; }
    }
}
