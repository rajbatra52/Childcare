using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Childcare.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class Users : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Users> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<Users>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Childcare.Models.Child> Children { get; set; }

        public System.Data.Entity.DbSet<Childcare.Models.Guardian> Guardians { get; set; }

        public System.Data.Entity.DbSet<Childcare.Models.Enrollment> Enrollments { get; set; }

        public System.Data.Entity.DbSet<Childcare.Models.ChildGuardian> ChildGuardians { get; set; }

        public System.Data.Entity.DbSet<Childcare.Models.ChildDay> ChildDays { get; set; }

        public System.Data.Entity.DbSet<Childcare.Models.AllUsers> AllUsers { get; set; }
    }
}