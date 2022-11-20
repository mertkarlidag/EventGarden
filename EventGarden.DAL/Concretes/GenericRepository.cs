using EventGarden.DAL.Contexts;
using EventGarden.DAL.Interfaces;
using EventGarden.Entities.Entitity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EventGarden.DAL.Concretes
{
    public class GenericRepository<T>:IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(T entity)
        {
          await  _context.Set<T>().AddAsync(entity);
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void Update(T entity, T unChanged)
        {
            _context.Entry(unChanged).CurrentValues.SetValues(entity);
        }
        public IQueryable<T> GetQuery()
        {
            return _context.Set<T>().AsQueryable();
        }
        public List<T> Where(Expression<Func<T,bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }
    }
}
