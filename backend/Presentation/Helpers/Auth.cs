using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Helpers
{
    public class Auth
    {
        public enum Roles
        {
            admin,
            user,
            employee
        }

        public const Roles rol_default = Roles.user;
    }
}