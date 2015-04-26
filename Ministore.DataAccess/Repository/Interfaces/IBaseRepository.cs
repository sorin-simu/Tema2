using System.Collections.Generic;

namespace Ministore.DataAccess.Repository.Interfaces
{

    public interface IBaseRepository<T> where T : class
    {

        void Add(T entity);
        void Delete(T entity);
        List<T> All();
        void Edit(T entity);

    }
}
