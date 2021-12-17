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
    public class StepService : IStepService
    {
        private readonly ApplicationDbContext _db;

        public StepService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Step> AddAsync(Step item)
        {
            if (GetAsync(item.ID) == null)
            {
                await _db.Steps.AddAsync(item);
                await _db.SaveChangesAsync();
                return item;
            }

            return null;
        }

        public async Task<IEnumerable<Step>> GetAllAsync()
        {
            return await _db.Steps.ToListAsync();
        }

        public async Task<Step> GetAsync(int id)
        {
            return await _db.Steps.FindAsync(id);
        }

        public async Task RemoveAsync(int id)
        {
            var item = await GetAsync(id);
            _db.Steps.Remove(item);
            await _db.SaveChangesAsync();
        }

        public async Task<Step> UpdateAsync(Step item)
        {
            var itemToUpdate = await GetAsync(item.ID);
            itemToUpdate.Users = item.Users;
            itemToUpdate.MeetLink = itemToUpdate.MeetLink;
            itemToUpdate.Badge = itemToUpdate.Badge;
            await _db.SaveChangesAsync();
            return itemToUpdate;
        }
    }
}
