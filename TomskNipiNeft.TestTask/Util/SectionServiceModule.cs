using Ninject.Modules;
using TestTask.BLL.Interfaces;
using TestTask.BLL.Services;

namespace TomskNipiNeft.TestTask.Util
{
    public class SectionServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISectionService>().To<SectionService>();
        }
    }
}