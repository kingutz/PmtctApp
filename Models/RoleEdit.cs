using Microsoft.AspNetCore.Identity;
using Pmtct.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pmtct.Models
{
    public class RoleEdit
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<ApplicationUser> MemberToRole { get; set; }
        public IEnumerable<ApplicationUser> NotMembersToRole { get; set; }
    }
}
