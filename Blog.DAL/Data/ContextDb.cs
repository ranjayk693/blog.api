using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.DAL.Models;
namespace Blog.DAL.Data
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions<ContextDb> options):base(options) {}

        // Registering the tables
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Blog.DAL.Models.Blog> Blogs { get; set; }
        //public DbSet<ReviewBlog> ReviewsBlog { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeding Failed because DataTime is dynmic
            //modelBuilder.Entity<BlogCategory>(c =>
            //{
            //    c.HasData(
            //        new BlogCategory { Id = 1, CategoryId = Guid.NewGuid().ToString(), CategoryName = "General", Description = "Default Category Name", IsActive = true, DateCreated = DateTime.Now, DateUpdated = DateTime.Now },
            //        new BlogCategory { Id = 2, CategoryId = Guid.NewGuid().ToString(), CategoryName = "AI", Description = "AI Related Blogs", IsActive = true, DateCreated = DateTime.Now, DateUpdated = DateTime.Now },
            //        new BlogCategory { Id = 3, CategoryId = Guid.NewGuid().ToString(), CategoryName = "Education", Description = "Education Related Blogs", IsActive = true, DateCreated = DateTime.Now, DateUpdated = DateTime.Now }
            //    );
            //});
            base.OnModelCreating(modelBuilder);
        }
    }
}
// General(default one) ,Coding, Life, Books,  

//INSERT INTO BlogCategories ( CategoryId, CategoryName, Description, IsActive, DateCreated, DateUpdated)
//VALUES 
//    ( '550e8400-e29b-41d4-a716-446655440000', 'General', 'Default Category Name', 1, '2024-01-01 00:00:00', '2024-01-01 00:00:00'),
//    ( '550e8400-e29b-41d4-a716-446655440001', 'AI', 'AI Related Blogs', 1, '2024-01-01 00:00:00', '2024-01-01 00:00:00'),
//    ( '550e8400-e29b-41d4-a716-446655440002', 'Education', 'Education Related Blogs', 1, '2024-01-01 00:00:00', '2024-01-01 00:00:00');
