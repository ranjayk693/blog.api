using Blog.BAL.CustomExcption;
using Blog.BAL.Dtos;
using Blog.BAL.Interface;
using Blog.DAL.Interface;
using Blog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BAL.Services
{
    public class CommonServiceBAL : ICommonServiceBAL
    {
        private readonly IUserServiceDAL _userServiceDAL;
        private readonly ICommonServiceDAL _commonServiceDAL;
        public CommonServiceBAL(IUserServiceDAL userServiceDAL, ICommonServiceDAL commonServiceDAL)
        {
            _userServiceDAL = userServiceDAL;
            _commonServiceDAL = commonServiceDAL;
        }

        public async Task<List<CategoryView>> GetCategories()
        {
            try
            {
                List<CategoryView> categoryViews = new List<CategoryView>();
                List<BlogCategory> categories = await _commonServiceDAL.GetCategories();
                foreach (BlogCategory category in categories)
                {
                    categoryViews.Add(new CategoryView
                    {
                        Id = category.CategoryId,
                        Name = category.CategoryName,
                    });
                }
                return categoryViews;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> CheckPermission(string PermissionId, string PermissionType = "User", int requireLevel = 0)
        {
            try
            {
                // check the Permission from Database nad return accrodingly
                Roles Role = await _commonServiceDAL.GetRoleById(PermissionId);
                if (Role is null)
                    throw new ForbiddenException("Role does not exists");

                string RoleName = Role.Name;
                int Level = Role.Level;
                if((RoleName == "SuperAdmin") || (RoleName == PermissionType) || (PermissionType == "User" && RoleName == "Admin"))
                {
                    // TODO
                    // Also check Level
                    // Add ENUMS
                    // Alternate Create Dictonary and Add the Values in it.
                    return true;
                }
                
                throw new ForbiddenException("You do net have Enough Permission, Please Contact Admin");
            }catch (Exception ex)
            {
                return false;
            }
        }
    }
}
