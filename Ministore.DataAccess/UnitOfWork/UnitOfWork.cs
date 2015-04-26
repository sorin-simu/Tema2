using System.Data.Entity.Infrastructure;
using Ministore.DataAccess.Repository.Interfaces;

namespace Ministore.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public ministoreDb DataContext { get; set; }
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private bool _disposed;

        public UnitOfWork(IObjectContextAdapter dataContext, IProductRepository productRepository,IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
            DataContext = (ministoreDb)dataContext;
        }

        public void SaveChanges()
        {
            DataContext.SaveChanges();
        }

        public IProductRepository ProductRepository
        {
            get { return _productRepository; }
        }

        public IUserRepository UserRepository
        {
            get { return _userRepository; }
        }

        protected void Dispose(bool disposable)
        {
            if (!_disposed)
            {
                if (disposable)
                {
                    if (DataContext != null)
                        DataContext.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
