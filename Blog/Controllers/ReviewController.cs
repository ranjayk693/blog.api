using Blog.BAL.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
//using System.Web.Http;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewServiceBAL _reviewServiceBAL;
        public ReviewController(IReviewServiceBAL reviewServiceBAL)
        {
            _reviewServiceBAL = reviewServiceBAL;
        }

        /// <summary>
        /// Add Review
        /// </summary>
        /// <param name="BlogId"></param>
        /// <param name="Review"></param>
        /// <returns></returns>
        [HttpPost("AddReview")]
        [Authorize]
        public async Task<IActionResult> AddReview(string BlogId, string Review)
        {
            try
            {
                string userId = User.FindFirst(ClaimTypes.Name).Value;
                await _reviewServiceBAL.Add(Review, BlogId, userId);
                return Ok();
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get All the reviews associated with blog
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("GetReviewByID")]
        public async Task<IActionResult> GetReviewByID(string BlogID)
        {
            try
            {
                var reviews = await _reviewServiceBAL.GetReviewById(BlogID);
                return Ok(reviews);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Delete Review
        // Edit Review
    }
}
