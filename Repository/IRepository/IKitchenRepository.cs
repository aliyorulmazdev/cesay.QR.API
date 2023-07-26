using cesay.QR.API.Models;
using System.Linq.Expressions;

namespace cesay.QR.API.Repository.IRepository
{
    public interface IKitchenRepository : IRepository<Kitchen>
    {
        Task<Kitchen> UpdateAsync(Kitchen entity);
    }
}
