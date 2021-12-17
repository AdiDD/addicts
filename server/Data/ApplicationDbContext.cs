using server.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace server.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<Badge> Badges { get; set; }

        internal Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Program>().ToTable("Programs");
            //modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationsUser");
            //modelBuilder.Entity<Post>().ToTable("Posts");
            //modelBuilder.Entity<Steps>().ToTable("")
            base.OnModelCreating(modelBuilder);
        }
    }
}
