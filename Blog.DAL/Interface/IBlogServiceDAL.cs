using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Interface
{
    public interface IBlogServiceDAL
    {
        
        Task<bool> AddBlogAsync(Blog.DAL.Models.Blog blog);
        Task<bool> EditBlog(string userID, Blog.DAL.Models.Blog blog);
        Task<bool> DeleteBlogAsync(string userId);
        Task<List<Models.Blog>> GetListByID(string userID);
        Task<List<Models.Blog>> GetBycategoryId(string categoryId);
        Task<List<Models.Blog>> GetRecentBlog();
        Task<Models.Blog> GetByBlogId(string BlogID);
        // Edit Blog
        //
    }
}