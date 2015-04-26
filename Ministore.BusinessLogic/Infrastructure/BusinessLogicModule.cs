using System.Collections.Generic;
using Ministore.BusinessLogic.Services.Implementations;
using Ministore.BusinessLogic.Services.Interfaces;
using Ministore.DataAccess.Infrastructure;
using Ninject.Modules;

namespace Ministore.BusinessLogic.Infrastructure
{
    public class BusinessLogicModule : NinjectModule
    {

        private readonly System.Func<Ninject.Activation.IContext, object> _scope;

        public BusinessLogicModule(System.Func<Ninject.Activation.IContext, object> scope)
        {
            _scope = scope;
        }

        public override void Load()
        {

            Kernel.Load(new List<NinjectModule> { new DataAccessModule(_scope) });
            Bind<IProductService>().To<ProductService>();
            Bind<IUserService>().To<UserService>();


        }
    }
}
