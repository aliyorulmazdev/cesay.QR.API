using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace cesay.QR.API.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public float Price { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }

        public void SetOrderTypeFromProduct(ProductVariant productVariant)
        {
            this.Type = ConvertToOrderType(productVariant.Product.Type);

            this.Price = productVariant.Price;
        }

        private string ConvertToOrderType(string orderType)
        {
            return orderType.ToString();
        }

        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }
        [ForeignKey("Table")]
        public int TableId { get; set; }
        [ForeignKey("ProductVariant")]
        public int ProductVariantId { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Table Table { get; set; }
        public Restaurant Restaurant { get; set; }
        public ProductVariant ProductVariant { get; set; }
    }
}
