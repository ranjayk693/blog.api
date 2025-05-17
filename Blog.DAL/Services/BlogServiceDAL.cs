using Blog.DAL.Data;
using Blog.DAL.Interface;
using Blog.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Services
{
    public class BlogServiceDAL : IBlogServiceDAL
    {
        private readonly ContextDb _db;
        public BlogServiceDAL(ContextDb db)
        {
            _db = db;
        }

        public async Task<bool> AddBlogAsync(Models.Blog blog)
        {
            try
            {
                blog.DateCreated = DateTime.Now;
                blog.DateUpdated = DateTime.Now;
                _db.Blogs.AddAsync(blog);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) 
            {
                throw new Exception($"Could not save, Please Contact Admin");
            }
        }

        public async Task<List<Models.Blog>> GetListByID(string userID)
        {
            try
            {
                List<Models.Blog> blogs = _db.Blogs.Where(u => u.UserID == userID).ToList();
                return blogs;
                //To-do --> Add Pagination
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Models.Blog>> GetBycategoryId(string categoryId)
        {
            try
            {
                List<Models.Blog> blogs = _db.Blogs.Where(u => u.CategoryId == categoryId).ToList();
                return blogs;
                //To-do --> Add Pagination
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<bool> DeleteBlogAsync(string blogId)
        {
            try
            {
                Models.Blog blog = _db.Blogs.FirstOrDefault(u => u.BlogId == blogId);
                blog.IsActive = false;
                blog.DateUpdated = DateTime.Now;
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not save, Please Contact Admin");
            }
        }

        public async Task<bool> EditBlog(string userID, Models.Blog blog)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Models.Blog>> GetRecentBlog()
        {
            try
            {
                List<Models.Blog> blogs = _db.Blogs.ToList();
                return blogs;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<Models.Blog> GetByBlogId(string BlogID)
        {
            try
            {
                return await _db.Blogs.FirstOrDefaultAsync(b => b.BlogId == BlogID);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
    }
}
