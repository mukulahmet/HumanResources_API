using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using Project.Models.Abstract;

namespace Project.DAL.Repositories.Abstract
{
    public interface IBaseRepository<TEntity> where TEntity : class, IBaseEntity
    {
        Task<TEntity> FindAsync(int id);
        Task<int> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(int id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();


        Task<IEnumerable<TResult>> ListeleAsync<TResult>(
           Expression<Func<TEntity, TResult>> select,
           Expression<Func<TEntity, bool>> where,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null
           );
    }
}
