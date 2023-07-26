using cesay.QR.API.Data;
using cesay.QR.API.Models;
using cesay.QR.API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace cesay.QR.API.Repository
{
    public class TableRepository : Repository<Table>, ITableRepository
    {
        private readonly ApplicationDbContext _context;

        public TableRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Table> UpdateAsync(Table entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _context.Tables.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
