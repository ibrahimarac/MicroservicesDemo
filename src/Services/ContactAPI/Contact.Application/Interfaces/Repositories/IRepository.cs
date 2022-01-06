using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Contact.Application.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity:class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetByFilter(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> GetById(Guid id);

        Task<TEntity> Add(TEntity entity);
        Task Delete(Guid id);
        Task Update(TEntity entity);
    }
}
