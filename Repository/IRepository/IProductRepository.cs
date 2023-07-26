using cesay.QR.API.Models;
using System.Linq.Expressions;

namespace cesay.QR.API.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> UpdateAsync(Product entity);
    }
}
