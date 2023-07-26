using cesay.QR.API.Models;
using System.Linq.Expressions;

namespace cesay.QR.API.Repository.IRepository
{
    public interface IProductVariantRepository : IRepository<ProductVariant>
    {
        Task<ProductVariant> UpdateAsync(ProductVariant entity);
    }
}
