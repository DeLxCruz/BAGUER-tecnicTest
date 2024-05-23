using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Domain.Entities
{
    public class Role 
    {
        public int IdRol { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; } = [];
    }
}