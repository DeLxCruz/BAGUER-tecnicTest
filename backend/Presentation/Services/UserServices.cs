using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Presentation.DTOs;
using Presentation.Helpers;

namespace Presentation.Services
{
    public class UserServices : IUserServices
    {
        private readonly JWT _jwt;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserServices(IOptions<JWT> jwt, IUnitOfWork unitOfWork, IPasswordHasher<User> passwordHasher)
        {
            _jwt = jwt.Value;
            _passwordHasher = passwordHasher;
            _unitOfWork = unitOfWork;
        }

        public async Task AddUserAsync(User user)
        {
            if (user.Role == null)
            {
                var defaultRole = await _unitOfWork.Roles.GetRoleByNameAsync("user");
                user.Role = defaultRole;
            }

            await _unitOfWork.Users.AddUserAsync(user);
            await _unitOfWork.SaveAsync();
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _unitOfWork.Users.GetUserByUsernameAsync(username);
        }

        public string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Username),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new("uid", user.IdUser.ToString())
            };

            if (user.Role != null)
            {
                claims.Add(new Claim(ClaimTypes.Role, user.Role.Description));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<DataUserDTO> GetTokenAsync(LoginDTO login)
        {
            DataUserDTO dataUser = new();

            var user = await _unitOfWork.Users.GetUserByUsernameAsync(login.Username);

            if (user != null)
            {
                Console.WriteLine($"Hashed password from DB: {user.Password}");

                var result = _passwordHasher.VerifyHashedPassword(user, user.Password, login.Password);

                Console.WriteLine($"Password Verification Result: {result}");

                if (result == PasswordVerificationResult.Success)
                {
                    dataUser.IsAuthenticated = true;
                    var jwtSecurityToken = GenerateToken(user);
                    dataUser.Token = jwtSecurityToken;
                    dataUser.UserName = user.Username;

                    dataUser.RefreshToken = GenerateRefreshToken();
                    dataUser.RefreshTokenExpiration = DateTime.UtcNow.AddDays(7);

                    return dataUser;
                }

                dataUser.IsAuthenticated = false;
                dataUser.Message = "Invalid Credentials";
                return dataUser;
            }

            dataUser.IsAuthenticated = false;
            dataUser.Message = "User not Found";
            return dataUser;
        }

        public async Task<Role> GetRoleByNameAsync(string Description)
        {
            return await _unitOfWork.Roles.GetRoleByNameAsync(Description);
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}