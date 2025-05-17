using Blog.DAL.Data;
using Blog.DAL.Interface;
using Blog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Services
{
    public class ReviewServiceDAL : IReviewServiceDAL
    {
        private readonly ContextDb _db;
        public ReviewServiceDAL(ContextDb db)
        {
            _db = db;
        }
        public async Task<bool> Add(Review Review)
        {
            try
            {
                Review.DateCreated = DateTime.Now;
                Review.DateUpdated = DateTime.Now;
                await _db.Reviews.AddAsync(Review);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<bool> Delete(string BlogId, string UserID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Review Review, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
