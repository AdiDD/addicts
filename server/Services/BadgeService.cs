using server.Services.Dependencies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Data;
using server.Models;

namespace server.Services
{
    public class BadgeService : IBadgeService
    {
        private readonly ApplicationDbContext _db;

        public BadgeService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Badge> AddAsync(Badge item)
        {
            if (GetAsync(item.ID) == null)
            {
                await _db.Badges.AddAsync(item);
                await _db.SaveChangesAsync();
                return item;
            }

            return null;
        }

        public async Task<IEnumerable<Badge>> GetAllAsync()
        {
            return await _db.Badges.ToListAsync();
        }

        public async Task<Badge> GetAsync(int id)
        {
            return await _db.Badges.FindAsync(id);
        }

        public async Task RemoveAsync(int id)
        {
            var item = await GetAsync(id);
            _db.Badges.Remove(item);
            await _db.SaveChangesAsync();
        }

        public async Task<Badge> UpdateAsync(Badge item)
        {
            var itemToUpdate = await GetAsync(item.ID);
            itemToUpdate.Title = item.Title;
            await _db.SaveChangesAsync();
            return itemToUpdate;
        }
    }
}
