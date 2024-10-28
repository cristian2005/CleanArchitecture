using CA.Core.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CA.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        #region Atributos
        protected readonly DbContext? _context;
        protected readonly DbSet<T>? _dbSet;

        #endregion

        #region Constructor
        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        #endregion

        #region MetodosGenericos
        public async Task AddAsync(T entity)
        {
            await _dbSet!.AddAsync(entity);
        }
        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet!.AddRangeAsync(entities);
        }
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
            =>  await _dbSet!.Where(expression).ToListAsync();
        public async Task<IEnumerable<T>> GetAllAsync()
            =>  await _dbSet!.ToListAsync();
        public async Task<T> GetByIdAsyn(int id) 
            =>  await _dbSet!.FindAsync(id);

        public void Remove(T entity)
        {
            _dbSet!.Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet!.RemoveRange(entities);
        }
        public void Update(T entity)
        {
            _dbSet!.Attach(entity);
            _context!.Entry(entity).State = EntityState.Modified;
        }
        #endregion

    }
}
