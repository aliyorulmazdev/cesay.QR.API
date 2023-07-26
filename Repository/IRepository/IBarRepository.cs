using cesay.QR.API.Models;
using System.Linq.Expressions;

namespace cesay.QR.API.Repository.IRepository
{
    public interface IBarRepository : IRepository<Bar>
    {
        Task<Bar> UpdateAsync(Bar entity);
    }
}
