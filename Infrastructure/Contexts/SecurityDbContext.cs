using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contexts
{
    public class SecurityDbContext : IdentityDbContext<IdentityUser>
    {

        public SecurityDbContext(DbContextOptions<SecurityDbContext> options) : base(options) { }
    }
}
