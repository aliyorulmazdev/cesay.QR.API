using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cesay.QR.API.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Latitude", "Longitude", "Name", "Rate", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 17, 15, 21, 15, 109, DateTimeKind.Utc).AddTicks(1747), "Şehrimizin en seçkin lezzet duraklarından biridir. Misafirlerine eşsiz bir yemek deneyimi sunan bu restoran, zengin menüsü ve şık atmosferiyle dikkat çekmektedir. İster iş toplantılarına ister özel kutlamalara uygun olan mekânımızda, lezzetli yemeklerle unutulmaz anlar yaşayabilirsiniz.", "https://www.happygroup.com.tr/uploads/source/2022/06/happy-01.jpg", 38.381934700000002, 27.112280500000001, "Munq", 4.4000000000000004, new DateTime(2023, 7, 17, 15, 21, 15, 109, DateTimeKind.Utc).AddTicks(1748) },
                    { 2, new DateTime(2023, 7, 17, 15, 21, 15, 109, DateTimeKind.Utc).AddTicks(1750), "Yemekseverlerin uğrak noktası haline gelen bir mekândır. Eşsiz lezzetler sunan bu restoran, sıcak ve samimi atmosferiyle de kendinizi evinizde hissetmenizi sağlar. En sevdiğiniz yemekleri tatmak ve yeni tatlar keşfetmek için Restoran 2'yi tercih edebilirsiniz.", "https://www.happygroup.com.tr/uploads/source/2022/06/happy-01.jpg", 38.381934700000002, 27.112280500000001, "Last Point", 4.5, new DateTime(2023, 7, 17, 15, 21, 15, 109, DateTimeKind.Utc).AddTicks(1750) },
                    { 3, new DateTime(2023, 7, 17, 15, 21, 15, 109, DateTimeKind.Utc).AddTicks(1752), "Eşsiz manzarası ve lezzetli yemekleriyle göz dolduran bir mekândır. Şehrin kalbinde bulunan bu restoran, ferah ve modern tasarımıyla dikkat çeker. Yüksek tavanları, geniş pencereleri ve rahat oturma alanlarıyla misafirlerine rahat ve huzurlu bir ortam sunar.", "https://www.happygroup.com.tr/uploads/source/2022/06/happy-01.jpg", 38.381934700000002, 27.112280500000001, "Kahve Diyarı", 4.5999999999999996, new DateTime(2023, 7, 17, 15, 21, 15, 109, DateTimeKind.Utc).AddTicks(1752) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
