using cesay.QR.API.Data;
using cesay.QR.API.Models;
using cesay.QR.API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace cesay.QR.API.Repository
{
    public class ProductVariantRepository : Repository<ProductVariant>, IProductVariantRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductVariantRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ProductVariant> UpdateAsync(ProductVariant entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _context.ProductVariants.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
