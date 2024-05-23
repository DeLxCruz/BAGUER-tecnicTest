using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repositories
{
    public class RoleRepository : IRole
    {
        private readonly BaguerDBContext _context;

        public RoleRepository(BaguerDBContext context)
        {
            _context = context;
        }
        
        public async Task<Role> GetRoleByNameAsync(string Description)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Description == Description);
        }
    }
}