using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ContactReport.Application.Repository
{
    public interface IRepository<TEntity> where TEntity:class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetByFilter(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> GetById(Guid id);

        Task Add(TEntity entity);
        Task Delete(Guid id);
        Task Update(TEntity entity);
    }
}
