using Blog.BAL.CustomExcption;
using Blog.BAL.Dtos;
using Blog.BAL.Interface;
using Blog.DAL.Dtos;
using Blog.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        // Write the Blog
        // Update the Blog
        // Delete the Blog
        // Get the Blog
        private readonly IBlogServiceBAL _blogServiceBAL;
        public BlogsController(IBlogServiceBAL BlogServiceBAL)
        {
            _blogServiceBAL = BlogServiceBAL;
        }

        /// <summary>
        /// Add Blog
        /// </summary>
        /// <param name="BlogView"></param>
        /// <returns></returns>
        [HttpPost("AddBlog")]
        [Authorize]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddBlog(BlogView BlogView)
        {
            try
            {
                //code
                string userID = User.FindFirst(ClaimTypes.Name).Value;
                string blogId = await _blogServiceBAL.AddBlogAsync(BlogView, userID);
                return Ok(blogId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Return List of Blog by UserId
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetByUser")]
        [Authorize]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<BlogView>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetListByUser()
        {
            try
            {
                string userID = User.FindFirst(ClaimTypes.Name).Value;
                List<BlogView> blogs = await _blogServiceBAL.GetAllBlogByID(userID);
                return Ok(blogs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Return List of Blog by CategoryId
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetByCategoryId")]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<BlogView>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetListByCategory(string categoryId)
        {
            try
            {
                //string userID = User.FindFirst(ClaimTypes.Name).Value;
                List<BlogView> blogs = await _blogServiceBAL.GetByCategoryIdAsync(categoryId);
                return Ok(blogs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get Recent Blogs
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetRecent")]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<BlogView>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRecentBlog()
        {
            try
            {
                //ToDo --> Add Pagination
                List<BlogView> blogs = await _blogServiceBAL.GetRecentBlogs();
                return Ok(blogs);

            }catch(Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Delete the Specific Blog
        /// </summary>
        /// <param name="blogID"></param>
        /// <returns></returns>
        [HttpDelete("DeleteBlog")]
        [Authorize]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(string blogID)
        {
            try
            {
                string userId = User.FindFirst(ClaimTypes.Name).Value;
                await _blogServiceBAL.DeleteByBlogIdAsync(blogID);
                return StatusCode(204);
            }
            catch (ForbiddenException ex)
            {
                return StatusCode(403, "Cannot Delete your Blog, Please Contact Admin to delete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get Blog By BlogID
        /// </summary>
        /// <param name="BlogID"></param>
        /// <returns></returns>
        [HttpGet("GetByBlogId")]
        public async Task<IActionResult> GetByBlogId(string BlogID)
        {
            try
            {
                BlogView blog = await _blogServiceBAL.GetByBlogId(BlogID);
                return Ok(blog);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        

        /// <summary>
        /// Testing The Blogs services
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        [HttpGet("Test")]
        public async Task<IActionResult> Test(string UserID)
        {
            await _blogServiceBAL.Test(UserID);
            return Ok();
        }



    }
}
