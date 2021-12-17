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
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _db;

        public UserService(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task<ApplicationUser> AddAsync(ApplicationUser item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {
            return await _db.ApplicationUsers.ToListAsync();
        }

        public async Task<ApplicationUser> GetAsync(int id)
        {
            return await _db.ApplicationUsers.FindAsync(id);
        }
        public async Task<ApplicationUser> GetAsync(string id)
        {
            return await _db.ApplicationUsers
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> UpdateAsync(ApplicationUser item)
        {
            var itemToUpdate = await GetAsync(item.Id);
            itemToUpdate.Email = item.Email;
            itemToUpdate.PhoneNumber = itemToUpdate.PhoneNumber;
            itemToUpdate.ProfilePicture = itemToUpdate.ProfilePicture;
            itemToUpdate.Badges = itemToUpdate.Badges;
            itemToUpdate.StepStartDate = itemToUpdate.StepStartDate;
            itemToUpdate.ProfilePicture = itemToUpdate.ProfilePicture;
            await _db.SaveChangesAsync();
            return itemToUpdate;
        }
    }
}
