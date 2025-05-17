using Blog.BAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BAL.Interface
{
    public interface IBlogServiceBAL
    {
        Task<string> AddBlogAsync(BlogView blogView, string userID);
        Task<List<BlogView>> GetAllBlogByID(string userId);
        Task<List<BlogView>> GetByCategoryIdAsync(string CategoryId);
        Task<List<BlogView>> GetRecentBlogs();
        Task<bool> DeleteByBlogIdAsync(string BlogId);
        Task<BlogView> GetByBlogId(string BlogID);
        //Task<List<CategoryView>> GetCategories();
        // Test
        Task Test(string test);
    }
}
