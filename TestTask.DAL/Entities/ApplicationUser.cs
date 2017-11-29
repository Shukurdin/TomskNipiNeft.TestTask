using Microsoft.AspNet.Identity.EntityFramework;

namespace TestTask.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual UserProfile UserProfile { get; set; }
    }
}
