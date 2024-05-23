using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Presentation.DTOs;

namespace Presentation.Services
{
    public interface IUserServices
    {
        Task<User> GetUserByUsernameAsync(string username);
        Task AddUserAsync(User user);
        Task<DataUserDTO> GetTokenAsync(LoginDTO model);
        string GenerateToken(User user);
        Task<Role> GetRoleByNameAsync(string Description);
    }
}