using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Project.DAL.Context;
using Project.DAL.Repositories.Abstract;
using Project.Models.Abstract;

namespace Project.DAL.Repositories.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity
    {

        protected readonly AppDBContext _dbContext;

        protected DbSet<T> _dbSet;

        public BaseRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            entity.CreationDate = DateTime.Now;
            entity.Status = Models.Enums.Status.Active;
            await _dbSet.AddAsync(entity);
            var result = await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await FindAsync(id);
            int kayitSayisi = 0;

            if (entity != null)
            {
                entity.DeletedDate= DateTime.Now;
                entity.Status = Models.Enums.Status.Passive;
                _dbSet.Update(entity);
                kayitSayisi = await _dbContext.SaveChangesAsync();
            }
            return kayitSayisi > 0 ? true : false;

        }

        public async Task<T> FindAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.Where(x => x.Status != Models.Enums.Status.Passive).ToListAsync();
        }

        public async Task<IEnumerable<TResult>> ListeleAsync<TResult>(Expression<Func<T, TResult>> select, Expression<Func<T, bool>> where, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _dbSet;
            if (where != null)
            {
                query = query.Where(where);
            }
            if (include != null)
            {
                query = include(query);
            }
            if (orderBy != null)
            {
                return await orderBy(query).Select(select).ToListAsync();
            }
            else
                return await query.Select(select).ToListAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            entity.ModifiedDate= DateTime.Now;
            entity.Status = Models.Enums.Status.Modified;

            _dbSet.Update(entity);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}
