using cesay.QR.API.Models;
using System.Linq.Expressions;

namespace cesay.QR.API.Repository.IRepository
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> UpdateAsync(Order entity);
    }
}
