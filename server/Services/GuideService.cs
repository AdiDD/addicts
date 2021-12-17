using server.Data;
using server.Models;
using server.Services.Dependencies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services
{
    public class GuideService : IGuideService
    {
        private readonly ApplicationDbContext _db;

        public GuideService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Guide> AddAsync(Guide item)
        {
            if (GetAsync(item.ID) == null)
            {
                await _db.Guides.AddAsync(item);
                await _db.SaveChangesAsync();
                return item;
            }

            return null;
        }

        public async Task<IEnumerable<Guide>> GetAllAsync()
        {
            return await _db.Guides.ToListAsync();
        }

        public async Task<Guide> GetAsync(int id)
        {
            return await _db.Guides.FindAsync(id);
        }

        public async Task RemoveAsync(int id)
        {
            var item = await GetAsync(id);
            _db.Guides.Remove(item);
            await _db.SaveChangesAsync();
        }

        public async Task<Guide> UpdateAsync(Guide item)
        {
            var itemToUpdate = await GetAsync(item.ID);
            itemToUpdate.MentorID = item.MentorID;
            itemToUpdate.Title = itemToUpdate.Title;
            itemToUpdate.Steps = itemToUpdate.Steps;
            itemToUpdate.Tags = itemToUpdate.Tags;
            await _db.SaveChangesAsync();
            return itemToUpdate;
        }
    }
}
