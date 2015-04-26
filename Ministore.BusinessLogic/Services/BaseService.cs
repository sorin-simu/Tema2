using Ministore.BusinessLogic.Services.Interfaces;
using Ministore.DataAccess.UnitOfWork;

namespace Ministore.BusinessLogic.Services
{
    public class BaseService : IBaseService
    {
        public IUnitOfWork UnitOfWork;

        public BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public void CommitUnitOfWork()
        {
            UnitOfWork.SaveChanges();
        }
    }
}
