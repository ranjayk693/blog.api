using Blog.BAL.Dtos;
using Blog.BAL.Interface;
using Blog.BAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ICommonServiceBAL _commonServiceBAl;
        public CommonController(ICommonServiceBAL commonServiceBAl)
        {
            _commonServiceBAl = commonServiceBAl;
        }

        /// <summary>
        /// Get the Category List
        /// </summary>
        /// <returns></returns>
        [HttpGet("getCategories")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                List<CategoryView> GetCategories = await _commonServiceBAl.GetCategories();
                return Ok(GetCategories);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
