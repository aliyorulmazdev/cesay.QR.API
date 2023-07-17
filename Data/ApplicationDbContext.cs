using cesay.QR.API.Models;
using Microsoft.EntityFrameworkCore;

namespace cesay.QR.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>().HasData(
            new Restaurant()
            {
                Id=1,
                Name="Munq",
                Description="Şehrimizin en seçkin lezzet duraklarından biridir. Misafirlerine eşsiz bir yemek deneyimi sunan bu restoran, zengin menüsü ve şık atmosferiyle dikkat çekmektedir. İster iş toplantılarına ister özel kutlamalara uygun olan mekânımızda, lezzetli yemeklerle unutulmaz anlar yaşayabilirsiniz.",
                Rate=4.4,
                Latitude=38.3819347,
                Longitude=27.1122805,
                ImageUrl="https://www.happygroup.com.tr/uploads/source/2022/06/happy-01.jpg",
                CreatedDate= DateTime.UtcNow,
                UpdatedDate= DateTime.UtcNow,
            },
            new Restaurant()
            {
                Id=2,
                Name="Last Point",
                Description="Yemekseverlerin uğrak noktası haline gelen bir mekândır. Eşsiz lezzetler sunan bu restoran, sıcak ve samimi atmosferiyle de kendinizi evinizde hissetmenizi sağlar. En sevdiğiniz yemekleri tatmak ve yeni tatlar keşfetmek için Restoran 2'yi tercih edebilirsiniz.",
                Rate=4.5,
                Latitude=38.3819347,
                Longitude=27.1122805,
                ImageUrl="https://www.happygroup.com.tr/uploads/source/2022/06/happy-01.jpg",
                CreatedDate= DateTime.UtcNow,
                UpdatedDate= DateTime.UtcNow,
            },
            new Restaurant()
            {
                Id=3,
                Name="Kahve Diyarı",
                Description="Eşsiz manzarası ve lezzetli yemekleriyle göz dolduran bir mekândır. Şehrin kalbinde bulunan bu restoran, ferah ve modern tasarımıyla dikkat çeker. Yüksek tavanları, geniş pencereleri ve rahat oturma alanlarıyla misafirlerine rahat ve huzurlu bir ortam sunar.",
                Rate=4.6,
                Latitude=38.3819347,
                Longitude=27.1122805,
                ImageUrl="https://www.happygroup.com.tr/uploads/source/2022/06/happy-01.jpg",
                CreatedDate= DateTime.UtcNow,
                UpdatedDate= DateTime.UtcNow,
            });
        }
    }
}