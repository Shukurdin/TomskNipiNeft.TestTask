using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Ninject.Web.Mvc;
using TestTask.BLL.Infrastructure;
using TomskNipiNeft.TestTask.Util;

namespace TomskNipiNeft.TestTask
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var sectionModule = new SectionServiceModule();
            var userServiceModule = new UserServiceModule();
            var repoModule = new RepositoryManagerModule("DefaultConnection");
            var kernel = new StandardKernel(sectionModule, repoModule, userServiceModule);
            kernel.Unbind<ModelValidatorProvider>();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
