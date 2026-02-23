using ElectionHawk.Web.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionHawk.Web
{
    public class ElectionHawkIdentityContext: IdentityDbContext<ElectionHawkIdentityUser, ElectionHawkIdentityRole, int>
    {

        public DbSet<ElectionHawkIdentityUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationUserPhoto> ApplicationUserPhotos { get; set; }
        public DbSet<ElectionHawkIdentityRole> ApplicationRoles { get; set; }
        public ElectionHawkIdentityContext(DbContextOptions<ElectionHawkIdentityContext> options):base(options)
        {


        }
    }
}
