using Blog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Interface
{
    public interface ICommonServiceDAL
    {
        Task<Roles> GetRoleById(string roleId);
        Task<List<BlogCategory>> GetCategories();

    }
}