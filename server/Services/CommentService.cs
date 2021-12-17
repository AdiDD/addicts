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
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _db;

        public CommentService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Comment> AddAsync(Comment item)
        {
            if (GetAsync(item.ID) == null)
            {
                await _db.Comments.AddAsync(item);
                await _db.SaveChangesAsync();
                return item;
            }

            return null;
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await _db.Comments.ToListAsync();
        }

        public async Task<Comment> GetAsync(int id)
        {
            return await _db.Comments.FindAsync(id);
        }

        public async Task RemoveAsync(int id)
        {
            var item = await GetAsync(id);
            _db.Comments.Remove(item);
            await _db.SaveChangesAsync();
        }

        public async Task<Comment> UpdateAsync(Comment item)
        {
            var itemToUpdate = await GetAsync(item.ID);
            itemToUpdate.Description = item.Description;
            itemToUpdate.Date = item.Date;
            await _db.SaveChangesAsync();
            return itemToUpdate;
        }
    }
}
