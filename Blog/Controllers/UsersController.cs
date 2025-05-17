using Auth0.AspNetCore.Authentication;
using Blog.BAL.CustomExcption;
using Blog.BAL.Dtos;
using Blog.BAL.Helper;
using Blog.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Web.Http.Description;
using static System.Net.Mime.MediaTypeNames;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly BAL.Interface.IUserServiceBAL _user;
        private readonly IHttpContextAccessor _contextAccessor;
        public UsersController(BAL.Interface.IUserServiceBAL user, IHttpContextAccessor contextAccessor)
        {
            _user = user;
            _contextAccessor = contextAccessor;
        }

        /// <summary>
        /// Register User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("RegisterUser")]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> RegisterUser(UserDtos user)
        {
            try
            {
                return Ok(await _user.AddUser(user));
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Activate the user
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet("ActivateUser")]
        public async Task<IActionResult> ActivateUser(string token)
        {
            try
            {
                // code
                // verify the token of user
                // Activate the user
                // return the Ok Message
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("RequestActivate")]
        public async Task<IActionResult> RequestAuthenticate(string email)
        {
            try
            {
                // Check if the user exist with ActivateUser
                // Send the mail token
                // Activate the User
                // Retuen Ok Message
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login(LoginDto login)
        {
            try
            {
                LoginResponse Token = await _user.Login(login);
                return Ok(Token);
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <returns></returns>
        [HttpDelete("DeleteAccount")]
        [Authorize]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteUser()
        {
            try
            {
                string userId = User.FindFirst(ClaimTypes.Name).Value;
                await _user.DeleteUser(userId);
                return StatusCode(204);
            }
            catch(ForbiddenException ex)
            {
                return StatusCode(403,"Cannot Delete your Account, Please Contact Admin to delete");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet("Login/Google")]
        //public async Task<IActionResult> SSO()
        //{
        //    try
        //    {
        //        var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
        //       .WithRedirectUri("/")
        //       .Build();
        //        var profile = new UserProfileViewModel()
        //        {
        //            Name = User.Identity.Name,
        //            EmailAddress = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value,
        //            ProfileImage = User.Claims.FirstOrDefault(c => c.Type == "picture")?.Value
        //        };
        //        return Ok(profile);
        //    }
        //    catch(Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        /// <summary>
        /// Testing for User Services
        /// </summary>
        /// <returns></returns>
        [HttpGet("Test")]
        [Authorize]
        public async Task<IActionResult> Test()
        {
            var user = User.FindFirst(ClaimTypes.Name);
            return Ok();
        }
        
    }
}
