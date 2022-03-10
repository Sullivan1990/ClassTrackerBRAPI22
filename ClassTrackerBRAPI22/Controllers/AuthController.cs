using ClassTrackerBRAPI22.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ClassTrackerBRAPI22.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly ClassTrackerContext _context;

        public AuthController(IConfiguration config, ClassTrackerContext context)
        {
            _configuration = config;
            _context = context;
        }

        // Add an initial user, only if no other user exists
        [HttpPost]
        [Route("CreateInitialUser")]
        public IActionResult CreateInitialUser(UserInfo _userData)
        {
            if (_userData != null && _userData.UserName != null && _userData.Password != null)
            {
                if (_context.Users.Count() != 0)
                {
                    return BadRequest();
                }
                // Add the initial User
                else
                {
                    // Take the entered password and Hash using the BCrypt Algorithm
                    string passwordHash = BCrypt.Net.BCrypt.HashPassword(_userData.Password);
                    _userData.Password = passwordHash;
                    _context.Add(_userData);
                    _context.SaveChangesAsync();
                    return Ok("User Created");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        // Generate a Token for an existing user
        [HttpPost]
        [Route("GenerateToken")]
        public IActionResult GenerateToken(UserInfo _userData)
        {
            // All of the null checks
            if (_userData != null && _userData.UserName != null && _userData.Password != null)
            {
                // retrieve the user for these credentials
                var user = GetUser(_userData.UserName, _userData.Password);

                // If we have a user that matches the credentials
                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                    // JWT Subject
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    // JWT ID
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    // JWT Date/Time
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    // JWT User ID
                    new Claim("Id", user.UserInfoId.ToString()),
                    // JWT UserName
                    new Claim("UserName", user.UserName)
                   };

                    // Generate a new key based on the Key we created and stored in appsettings.json
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    // use the generated key to generate new Signing Credentials
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    // Generate a new token based on all of the details generated so far
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        // How long the JWT will be valid for
                        expires: DateTime.UtcNow.AddDays(2),
                        signingCredentials: signIn);

                    // Return the Token via JSON
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }



        private UserInfo GetUser(string userName, string password)
        {
            // Use the BCrypt.Verify method to verify the entered password 
            // when hashed matches the hashed password

            var user = _context.Users.FirstOrDefault(u => u.UserName == userName);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return user;
            }
            return null;

        }

    }
}
