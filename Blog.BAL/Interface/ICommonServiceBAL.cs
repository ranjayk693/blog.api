using Blog.BAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BAL.Interface
{
    public interface ICommonServiceBAL
    {
        Task<bool> CheckPermission(string PermissionId, string PermissionType, int requireLevel = 0);
        Task<List<CategoryView>> GetCategories();
    }
}
