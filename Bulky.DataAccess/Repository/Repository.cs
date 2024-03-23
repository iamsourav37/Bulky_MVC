using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bulky.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;


namespace Bulky.DataAccess.Repository
{
    public class Repository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDBContext dBContext)
        {
            this._dbContext = dBContext;
            this._dbSet = this._dbContext.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _dbSet;
            query = query.Where(predicate);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = _dbSet;
            return query.ToList();
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}
