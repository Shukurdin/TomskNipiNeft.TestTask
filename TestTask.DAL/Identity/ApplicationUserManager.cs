using Microsoft.AspNet.Identity;
using TestTask.DAL.Entities;

namespace TestTask.DAL.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store) { }
    }
}