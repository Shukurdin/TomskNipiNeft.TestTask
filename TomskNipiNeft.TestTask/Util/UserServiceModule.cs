using Ninject.Modules;
using TestTask.BLL.Interfaces;
using TestTask.BLL.Services;

namespace TomskNipiNeft.TestTask.Util
{
    public class UserServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
        }
    }
}