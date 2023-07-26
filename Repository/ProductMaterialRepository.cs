using cesay.QR.API.Data;
using cesay.QR.API.Models;
using cesay.QR.API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace cesay.QR.API.Repository
{
    public class ProductMaterialRepository : Repository<ProductMaterial>, IProductMaterialRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductMaterialRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ProductMaterial> UpdateAsync(ProductMaterial entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _context.ProductMaterials.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
