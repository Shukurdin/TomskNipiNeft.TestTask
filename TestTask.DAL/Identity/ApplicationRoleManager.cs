using Microsoft.AspNet.Identity;
using TestTask.DAL.Entities;

namespace TestTask.DAL.Identity
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> store) 
            : base(store){ }
    }
}