using cesay.QR.API.Models;
using System.Linq.Expressions;

namespace cesay.QR.API.Repository.IRepository
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        Task<Recipe> UpdateAsync(Recipe entity);
    }
}
