using Blog.DAL.Data;
using Blog.DAL.Interface;
using Blog.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Services
{
    public class UserServiceDAL : IUserServiceDAL
    {
        private readonly ContextDb _db;
        public UserServiceDAL(ContextDb db)
        {
            _db = db;
        }
        public async Task<bool> AddUser(Models.User user)
        {
            user.ID = 0;
            user.DateCreated = DateTime.Now;
            user.DateUpdated = DateTime.Now;
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUser(string userId)
        {
            try
            {
                User user = await _db.Users.FirstOrDefaultAsync(e => e.UserID == userId);
                user.IsActive = false;
                await _db.SaveChangesAsync();
                return true;    
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public Task<bool> ForgotPassword(string EmailId)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByBlogId(string BlogId)
        {
            try
            {
                User user = await (from u in _db.Users
                             join b in _db.Blogs on u.UserID equals b.UserID
                             where b.BlogId == BlogId
                             select u).FirstOrDefaultAsync();
                return user;
            }
            catch (Exception ex) { 
                throw new Exception(ex.Message);
            }
        }

        public async Task<Models.User> GetByEmail(string email)
        {
            return await _db.Users.FirstOrDefaultAsync(user => user.UserEmail == email);
        }

        public async Task<Models.User> GetById(string ID)
        {
            return await _db.Users.FirstOrDefaultAsync(user => user.UserID == ID);
        }

        //public async Task<string> Get
    }
}
