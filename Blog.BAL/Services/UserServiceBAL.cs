using Blog.BAL.CustomExcption;
using Blog.BAL.Dtos;
using Blog.BAL.Helper;
using Blog.BAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.DAL.Models;
using Blog.DAL.Interface;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;

namespace Blog.BAL.Services
{
    public class UserServiceBAL : IUserServiceBAL
    {
        private readonly IConfiguration _config;
        private readonly IUserServiceDAL _user;
        //private readonly 
        // Get the Role
        public UserServiceBAL(IUserServiceDAL user, IConfiguration config)
        {
            _user = user;
            _config = config;
        }

        public async Task<bool> AddUser(UserDtos userDto)
        {
            try
            {
                User tempUser = await _user.GetByEmail(userDto.UserEmail);
                if (tempUser is not null)
                {
                    if (tempUser.IsActive is false)
                        throw new Exception("This account is deleted one please contact admin to activate");
                    else
                        throw new Exception($"Account already exits with {userDto.UserEmail}");
                }

                User user = new User();
                user.UserID = Guid.NewGuid().ToString();
                user.IsActive = false;
                user.IsArchieve = false;
                user.UserName = userDto.UserName;
                user.UserEmail = userDto.UserEmail;
                user.Password = EncodingDecoding.HashPassword(userDto.Password);
                user.PhoneNumber = userDto?.PhoneNumber ?? null;
                user.FirstName = userDto.FirstName;
                user.MiddleName = userDto?.MiddleName ?? null;
                user.LastName = userDto?.LastName ?? null;
                user.RoleID = "8DB49539-4FD7-47A9-8C9C-2E1F33214E1B"; // change later on as default ID
                
                // their is another end point point which will add the image of the user
                bool IsRegister = await _user.AddUser(user);

                // Generate the Email verification part and when clicked link it will automtically Activate the Account
                return IsRegister;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteUser(string UserID)
        {
            try
            {
                //code
                //User user = await _user.GetById(UserID);
                bool IsDeleted = await _user.DeleteUser(UserID);
                if (IsDeleted)
                    return true;
                return false;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }

        public async Task<LoginResponse> Login(LoginDto login)
        {
            try
            {
                User user = await _user.GetByEmail(login.Email);
                if (user == null)
                    throw new NotFoundException("User does not exists, please Login With Correct Email");

                // Decrypt the ATOB


                // Ckech the Creadential
                bool IsValid = EncodingDecoding.VerifyPassword(user.Password,login.Password );

                if(!IsValid)
                    throw new Exception("Your Credential is not correct");

                return new LoginResponse { Token = await GenerateToken(user.UserEmail, user.UserID, user.UserID) }; 
                    
            }
            catch(NotFoundException ex)
            {
                throw new NotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ActivateUser(string token)
        {
            try
            {
                // Decode the token
                // Find the User
                // If user exists and It is in Non-Acitvate mode then Activate the user
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Request2Activate(string email, string token = null)
        {
            try
            {
                // Check if the token is null and given email User Exists or not with InActive State , If not throw exception
                // If token is not null then send then bind the token with email template OtherWise create token and bind
                // Bind the token with email template to register the User
                // create a helper class to create a template and to send the Email
                return true;
                // Inside the Email Once Clicked on link then Activate the User by calling ActivaeUser api
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<string> GenerateToken(string UserEmail, string UserId, string RoleName)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,UserId),
                new Claim(ClaimTypes.Email, UserEmail),
                //new Claim(ClaimTypes.Role, RoleId),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim("ExpiryDate", DateTime.Now.AddHours(1).ToString())
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        
    }
}