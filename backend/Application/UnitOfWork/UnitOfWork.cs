using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private readonly BaguerDBContext _context;

        public UnitOfWork(BaguerDBContext context)
        {
            _context = context;
        }

        private UserRepository _users;
        public IUser Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new UserRepository(_context);
                }

                return _users;
            }
        }

        private IRole _roles;
        public IRole Roles
        {
            get
            {
                if (_roles == null)
                {
                    _roles = new RoleRepository(_context);
                }
                
                return _roles;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}