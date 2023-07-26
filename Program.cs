using cesay.QR.API;
using cesay.QR.API.Data;
using cesay.QR.API.Repository;
using cesay.QR.API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(option => {
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});

builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddScoped<IBarRepository, BarRepository>(); // Add BarRepository interface
builder.Services.AddScoped<IKitchenRepository, KitchenRepository>(); // Add KitchenRepository interface
builder.Services.AddScoped<IOrderRepository, OrderRepository>(); // Add OrderRepository interface
builder.Services.AddScoped<IProductRepository, ProductRepository>(); // Add ProductRepository interface
builder.Services.AddScoped<IProductMaterialRepository, ProductMaterialRepository>(); // Add ProductMaterialRepository interface
builder.Services.AddScoped<IProductVariantRepository, ProductVariantRepository>(); // Add ProductVariantRepository interface
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>(); // Add RecipeRepository interface
builder.Services.AddScoped<ITableRepository, TableRepository>(); // Add TableRepository interface

builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddControllers(options =>
{
    //options.ReturnHttpNotAcceptable=true;
}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
