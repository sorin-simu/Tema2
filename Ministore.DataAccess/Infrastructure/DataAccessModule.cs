using System.Data.Entity.Infrastructure;
using Ministore.DataAccess.Repository.Implementations;
using Ministore.DataAccess.Repository.Interfaces;
using Ministore.DataAccess.UnitOfWork;
using Ninject.Modules;

namespace Ministore.DataAccess.Infrastructure
{
    public class DataAccessModule : NinjectModule
    {
        private readonly System.Func<Ninject.Activation.IContext, object> _scope;

        public DataAccessModule(System.Func<Ninject.Activation.IContext, object> scope)
        {
            _scope = scope;
        }
        public override void Load()
        {
            Bind<IObjectContextAdapter>().To<ministoreDb>().InScope(_scope);
            Bind<IUserRepository>().To<UserRepository>();
            Bind<IProductRepository>().To<ProductRepository>();
            Bind<IUnitOfWork>().To<UnitOfWork.UnitOfWork>();
        }
    }
}
