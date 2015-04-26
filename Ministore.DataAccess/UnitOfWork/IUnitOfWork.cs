using System;
using Ministore.DataAccess.Repository.Interfaces;

namespace Ministore.DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }
        IUserRepository UserRepository { get; }
        ministoreDb DataContext { get; set; }
        void SaveChanges();
    }

}
