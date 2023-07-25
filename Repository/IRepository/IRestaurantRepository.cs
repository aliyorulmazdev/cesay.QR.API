using cesay.QR.API.Models;
using System.Linq.Expressions;

namespace cesay.QR.API.Repository.IRepository
{
    public interface IRestaurantRepository : IRepository<Restaurant>
    {
        Task<Restaurant> UpdateAsync(Restaurant entity);
    }
}
