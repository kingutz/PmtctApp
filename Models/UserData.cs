using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pmtct.Models
{
    public class UserData
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        public Role[] roles { get; set; }
    }
}
