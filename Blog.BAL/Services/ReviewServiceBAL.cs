using Blog.BAL.Dtos;
using Blog.BAL.Interface;
using Blog.DAL.Data;
using Blog.DAL.Interface;
using Blog.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BAL.Services
{
    public class ReviewServiceBAL : IReviewServiceBAL
    {
        private readonly IReviewServiceDAL _reviewServiceDAL;
        private readonly IUserServiceDAL _userServiceDAL;
        public ReviewServiceBAL(IReviewServiceDAL reviewServiceDAL, IUserServiceDAL userServiceDAL)
        {
            _reviewServiceDAL = reviewServiceDAL;
            _userServiceDAL = userServiceDAL;
        }
        public async Task<bool> Add(string Review, string BlogId, string UserId)
        {
            try
            {
                Blog.DAL.Models.Review review = new Blog.DAL.Models.Review
                {
                    ReviewId = Guid.NewGuid().ToString(),
                    UserId = UserId,
                    Description = Review,
                    IsActive = true,
                    BlogId = BlogId   
                };
                await _reviewServiceDAL.Add(review);
                return true;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<bool> Delete(string ReviewId, string UserId)
        {
            throw new NotImplementedException();
        }

        public async Task<ReviewViewModel> GetReviewById(string BlogId)
        {
            try
            {
                User user = await _userServiceDAL.GetByBlogId(BlogId);
                ReviewViewModel result = new ReviewViewModel
                {
                    Author = user.FirstName + ' ' + user.MiddleName + ' ' + user.LastName,
                    ReviewsViews = new List<ReviewsView>()
                };
                DataSet dataSet = ADONetDb.ExecuteSp("GetReviewsListByBlogId",
                    new Microsoft.Data.SqlClient.SqlParameter("@BlogId", SqlDbType.NVarChar) { Value = BlogId });
                if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        result.ReviewsViews.Add(new ReviewsView
                        {
                            ReviewId = row["ReviewId"].ToString(),
                            Name = row["ReviewerName"].ToString(),
                            Description = row["Description"].ToString()
                        });
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<bool> Update(string Review, string ReviewID, string UserId)
        {
            throw new NotImplementedException();
        }
    }
}
