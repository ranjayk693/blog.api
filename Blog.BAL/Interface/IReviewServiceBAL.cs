using Blog.BAL.Dtos;
using Blog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BAL.Interface
{
    public interface IReviewServiceBAL
    {
        Task<ReviewViewModel> GetReviewById(string BlogId);
        Task<bool> Add(string Review, string BlogId , string UserId);
        Task<bool> Update(string Review, string ReviewID, string UserId);
        Task<bool> Delete(string ReviewId , string UserId);
    }
}
