using cesay.QR.API.Data;
using cesay.QR.API.Models;
using cesay.QR.API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace cesay.QR.API.Repository
{
    public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
    {
        private readonly ApplicationDbContext _context;

        public RestaurantRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Restaurant> UpdateAsync(Restaurant entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _context.Restaurants.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
