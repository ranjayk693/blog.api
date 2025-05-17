using Blog.BAL.Dtos;
using Blog.BAL.Interface;
using Blog.DAL.Interface;
using Blog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Blog.BAL.Services
{
    public class BlogServiceBAL : IBlogServiceBAL
    {
        private readonly IBlogServiceDAL _blogServiceDAL;
        private readonly ICommonServiceDAL _commonServiceDAL;
        private readonly IGenericServiceDAL<Blog.DAL.Models.Blog> _blogDAL;
        public BlogServiceBAL(IBlogServiceDAL blogServiceDAL, ICommonServiceDAL commonServiceDAL, IGenericServiceDAL<Blog.DAL.Models.Blog> blogDAL)
        {
            _blogServiceDAL = blogServiceDAL;
            _commonServiceDAL = commonServiceDAL;
            _blogDAL = blogDAL;
        }

        public async Task<string> AddBlogAsync(BlogView blogView, string userID)
        {
            try
            {
                Blog.DAL.Models.Blog blog = new Blog.DAL.Models.Blog
                {
                    BlogId = Guid.NewGuid().ToString(),
                    UserID = userID,
                    Title = blogView.Title,
                    Description = blogView.Description,
                    CategoryId = blogView.CategoryId,
                    IsActive = true
                };
                await _blogServiceDAL.AddBlogAsync(blog);
                return blog.BlogId;
                // ToDo --> Create Custom Error Exception to throw the MEsssage to frontend
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<BlogView>> GetAllBlogByID(string userId)
        {
            try
            {
                List<BlogView> blogViewList = new List<BlogView>();
                List<Blog.DAL.Models.Blog> blogList = new List<Blog.DAL.Models.Blog>();
                // ToDo --> Add Paginaition
                blogList = await _blogServiceDAL.GetListByID(userId);
                blogList.ForEach(blog => {
                    blogViewList.Add(new BlogView
                    {
                        Title = blog.Title,
                        Description = blog.Description,
                        CategoryId = blog.CategoryId,
                    });
                });
                return blogViewList;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<BlogView>> GetByCategoryIdAsync(string CategoryId)
        {
            try
            {
                // For Testing Purpose
                List<BlogView> blogViewList = new List<BlogView>();
                List<Blog.DAL.Models.Blog> blogList = new List<Blog.DAL.Models.Blog>();
                // ToDo --> Add Paginaition from the database side
                blogList = await _blogServiceDAL.GetBycategoryId(CategoryId);
                blogList.ForEach(blog => {
                    blogViewList.Add(new BlogView
                    {
                        Title = blog.Title,
                        Description = blog.Description,
                        CategoryId = blog.CategoryId,
                    });
                });
                return blogViewList;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteByBlogIdAsync(string BlogId)
        {
            try
            {
                await _blogServiceDAL.DeleteBlogAsync(BlogId);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<BlogView> GetByBlogId(string BlogID)
        {
            try
            {
                DAL.Models.Blog blogs = await _blogServiceDAL.GetByBlogId(BlogID);
                if(blogs == null)
                    throw new Exception("Wrong BlogId");
                BlogView blogView = new BlogView
                {
                    Title = blogs?.Title,
                    Description = blogs?.Description,
                    CategoryId = blogs?.CategoryId,
                    Id = blogs?.BlogId,
                };
                return blogView;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        // Failed
        public async Task Test(string test)
        {
            try
            {
                var result = await _blogDAL.FindAsync(b=> b.UserID == test); // This is of type boolean
                var todo = false;
            }
            catch(Exception ex)
            {
                throw new Exception("Test is Failed");
            }
        }

        public async Task<List<BlogView>> GetRecentBlogs()
        {
            try
            {
                List<BlogView> blogViewList = new List<BlogView>();
                List<Blog.DAL.Models.Blog> blogList = new List<Blog.DAL.Models.Blog>();
                // ToDo --> Add Paginaition from the database
                blogList = await _blogServiceDAL.GetRecentBlog();
                blogList.ForEach(blog => {
                    blogViewList.Add(new BlogView
                    {
                        Id = blog.BlogId,
                        Title = blog.Title,
                        Description = blog.Description,
                        CategoryId = blog.CategoryId,
                    });
                });
                return blogViewList;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
