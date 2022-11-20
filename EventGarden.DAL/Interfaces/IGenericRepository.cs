using EventGarden.Entities.Entitity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EventGarden.DAL.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
         Task CreateAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        void Remove(T entity);
        void Update(T entity, T unChanged);
        IQueryable<T> GetQuery();
        List<T> Where(Expression<Func<T, bool>> predicate);

    }
}
