using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Ministore.DataAccess.Repository.Interfaces;

namespace Ministore.DataAccess.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        protected readonly DbSet<T> DbSet;
        protected readonly ministoreDb DataContext;

        public BaseRepository(IObjectContextAdapter dbContext)
        {
            DataContext = (ministoreDb)dbContext;
            DbSet = DataContext.Set<T>();
        }

        public List<T> All()
        {
            return DbSet.Distinct().ToList();
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
            DataContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            DbSet.Attach(entity);
            DataContext.Entry(entity).State = EntityState.Deleted;
            DataContext.SaveChanges();
        }

        public void Edit(T entity)
        {
                DbSet.Attach(entity);
                DataContext.Entry(entity).State = EntityState.Modified;
                DataContext.SaveChanges();

        }




    }
}
