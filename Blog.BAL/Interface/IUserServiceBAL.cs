using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.BAL.Dtos;
using Blog.DAL.Models;
namespace Blog.BAL.Interface
{
    public interface IUserServiceBAL
    {
        Task<bool> AddUser(UserDtos user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(string UserID);
        Task<bool> ActivateUser(string token);
        Task<bool> Request2Activate(string email, string token = null);
        Task<LoginResponse> Login(LoginDto login);
    }
}
