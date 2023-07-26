﻿using cesay.QR.API.Data;
using cesay.QR.API.Models;
using cesay.QR.API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace cesay.QR.API.Repository
{
    public class KitchenRepository : Repository<Kitchen>, IKitchenRepository
    {
        private readonly ApplicationDbContext _context;

        public KitchenRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Kitchen> UpdateAsync(Kitchen entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _context.Kitchens.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
