using cesay.QR.API.Models;
using System.Linq.Expressions;

namespace cesay.QR.API.Repository.IRepository
{
    public interface IProductMaterialRepository : IRepository<ProductMaterial>
    {
        Task<ProductMaterial> UpdateAsync(ProductMaterial entity);
    }
}
