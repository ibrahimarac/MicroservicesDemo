using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Contact.Application.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity:class
    {
        Task<IEnumerable<TEntity>> GetAll(bool tracking=false);
        Task<IEnumerable<TEntity>> GetByFilter(Expression<Func<TEntity, bool>> filter,bool tracking=false);
        Task<TEntity> GetById(Guid id,bool tracking=false);

        Task<TEntity> Add(TEntity entity);
        Task Delete(Guid id);
        Task<TEntity> Update(TEntity entity);
    }
}
