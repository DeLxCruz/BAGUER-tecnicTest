using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.DTOs
{
    public class RegisterDTO
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public string Name { get; set; }
    }
}