using cesay.QR.API.Models;
using System.Linq.Expressions;

namespace cesay.QR.API.Repository.IRepository
{
    public interface ITableRepository : IRepository<Table>
    {
        Task<Table> UpdateAsync(Table entity);
    }
}
