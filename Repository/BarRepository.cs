using cesay.QR.API.Data;
using cesay.QR.API.Models;
using cesay.QR.API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace cesay.QR.API.Repository
{
    public class BarRepository : Repository<Bar>, IBarRepository
    {
        private readonly ApplicationDbContext _context;

        public BarRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Bar> UpdateAsync(Bar entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _context.Bars.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
