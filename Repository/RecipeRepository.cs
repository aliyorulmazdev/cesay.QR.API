using cesay.QR.API.Data;
using cesay.QR.API.Models;
using cesay.QR.API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace cesay.QR.API.Repository
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        private readonly ApplicationDbContext _context;

        public RecipeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Recipe> UpdateAsync(Recipe entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _context.Recipes.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
