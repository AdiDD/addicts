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
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _db;

        public PostService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Post> AddAsync(Post item)
        {
            if (GetAsync(item.ID) == null)
            {
                await _db.Posts.AddAsync(item);
                await _db.SaveChangesAsync();
                return item;
            }

            return null;
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await _db.Posts.ToListAsync();
        }

        public async Task<Post> GetAsync(int id)
        {
            return await _db.Posts.FindAsync(id);
        }

        public async Task RemoveAsync(int id)
        {
            var item = await GetAsync(id);
            _db.Posts.Remove(item);
            await _db.SaveChangesAsync();
        }

        public async Task<Post> UpdateAsync(Post item)
        {
            var itemToUpdate = await GetAsync(item.ID);
            itemToUpdate.Description = item.Description;
            itemToUpdate.PhotoURL = itemToUpdate.PhotoURL;
            itemToUpdate.Date = itemToUpdate.Date;
            itemToUpdate.Comments = itemToUpdate.Comments;
            itemToUpdate.UsersThatLiked = itemToUpdate.UsersThatLiked;
            await _db.SaveChangesAsync();
            return itemToUpdate;
        }
    }
}
