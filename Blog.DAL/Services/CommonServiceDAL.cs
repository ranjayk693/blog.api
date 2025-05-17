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
    public class CommonServiceDAL : ICommonServiceDAL
    {
        private readonly ContextDb _db;
        public CommonServiceDAL(ContextDb contextDb)
        {
            _db = contextDb;
        }
        public async Task<Roles> GetRoleById(string RoleID)
        {
            Roles RoleInfo = await _db.Roles
                .Where(r => r.RoleID == RoleID)
                .Select(r => new Roles
                {
                    Name = r.Name,
                    Level = r.Level
                })?.FirstOrDefaultAsync();
            return RoleInfo;
        }



        public async Task<List<BlogCategory>> GetCategories()
        {
            try
            {
                List<BlogCategory> categories = await _db.BlogCategories.Where(c => c.IsActive == true).ToListAsync();
                return categories;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public async Task<bool> MappedReviewBlogUser(string userId, string BlogId, string ReviewID)
        //{
        //    // userId + BlogID --> Used When Adding New Blog
        //    // UserId + Review
        //}
    }
}
