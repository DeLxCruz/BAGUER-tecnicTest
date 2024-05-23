using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTOs;
using Presentation.Services;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserController(IUserServices userServices, IPasswordHasher<User> passwordHasher)
        {
            _userServices = userServices;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            var existingUser = await _userServices.GetUserByUsernameAsync(registerDTO.Username);

            if (existingUser != null)
            {
                return BadRequest("User already exists.");
            }

            Console.WriteLine($"Plain password: {registerDTO.Password}");

            var user = new User
            {
                Username = registerDTO.Username,
                Name = registerDTO.Name
            };
            user.Password = _passwordHasher.HashPassword(user, registerDTO.Password);

            Console.WriteLine($"Hashed password: {user.Password}");

            var role = await _userServices.GetRoleByNameAsync("user");

            if (role == null)
            {
                return BadRequest("Role not found.");
            }

            user.RoleId = role.IdRol;

            await _userServices.AddUserAsync(user);

            return Ok("User created successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> GetTokeAsync(LoginDTO userLoginDTO)
        {
            var result = await _userServices.GetTokenAsync(userLoginDTO);

            if (result.IsAuthenticated)
            {
                if (!string.IsNullOrEmpty(result.RefreshToken))
                {
                    SetRefreshTokenInCookie(result.RefreshToken);
                }

                return Ok(
                    new
                    {
                        result.IsAuthenticated,
                        token = result.Token,
                        username = result.UserName,
                        role = result.Roles,
                        result.RefreshToken,
                    }
                );
            }
            return Unauthorized(result);

        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetUserByUsernameAsync(string username)
        {
            var user = await _userServices.GetUserByUsernameAsync(username);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        private void SetRefreshTokenInCookie(string refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(10),
            };
            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }
    }
}