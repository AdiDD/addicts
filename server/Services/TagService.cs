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
    public class TagService : ITagService
    {
        private readonly ApplicationDbContext _db;

        public TagService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Tag> AddAsync(Tag item)
        {
            if (GetAsync(item.ID) == null)
            {
                await _db.Tags.AddAsync(item);
                await _db.SaveChangesAsync();
                return item;
            }

            return null;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await _db.Tags.ToListAsync();
        }

        public async Task<Tag> GetAsync(int id)
        {
            return await _db.Tags.FindAsync(id);
        }

        public async Task RemoveAsync(int id)
        {
            var item = await GetAsync(id);
            _db.Tags.Remove(item);
            await _db.SaveChangesAsync();
        }

        public async Task<Tag> UpdateAsync(Tag item)
        {
            var itemToUpdate = await GetAsync(item.ID);
            itemToUpdate.Title = item.Title;
            await _db.SaveChangesAsync();
            return itemToUpdate;
        }
    }
}
