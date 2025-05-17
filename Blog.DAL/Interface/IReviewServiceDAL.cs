using Blog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Interface
{
    public interface IReviewServiceDAL
    {
        Task<bool> Add(Review Review);
        Task<bool> Update(Review Review, string userId);
        Task<bool> Delete(string BlogId, string UserID);
    }
}
