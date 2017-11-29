using Ninject.Modules;
using TestTask.DAL.Interfaces;
using TestTask.DAL.Repositories;

namespace TestTask.BLL.Infrastructure
{
    public class RepositoryManagerModule : NinjectModule
    {
        private readonly string _connectionString;

        public RepositoryManagerModule(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public override void Load()
        {
            Bind<IRepositoryManager>().To<RepositoryManager>()
                .WithConstructorArgument(_connectionString);
        }
    }
}