using Blog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Interface
{
    public interface IUserServiceDAL
    {
        Task<bool> AddUser(User user);
        Task<User> GetById(string ID);
        Task<User> GetByEmail(string Name);
        Task<bool> DeleteUser(string userId);
        Task<bool> ForgotPassword(string EmailId);
        Task<User> GetByBlogId(string BlogId);
    }
}