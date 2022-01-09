using Microsoft.EntityFrameworkCore;
using Report.Application.Interfaces.Common;
using Report.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IReportDbContext _context;
        private readonly DbSet<TEntity> _entities;

        public Repository(IReportDbContext context)
        {
            _context = context;
            _entities = Context.Set<TEntity>();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            await _entities.AddAsync(entity);
            await Context.SaveChangesAsync(new CancellationToken(false));
            return entity;
        }

        public async Task Delete(Guid id)
        {
            var entity= await _entities.FindAsync(id);
            Context.Remove(entity);
            await Context.SaveChangesAsync(new CancellationToken(false));
        }

        public async Task<IEnumerable<TEntity>> GetAll(bool tracking = false)
        {
            return tracking ?
                await _entities.ToListAsync()
                :
                await _entities.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetByFilter(Expression<Func<TEntity, bool>> filter, bool tracking = false)
        {
            return tracking ?
                await _entities.Where(filter).AsNoTracking().ToListAsync()
                :
                await _entities.Where(filter).ToListAsync();
        }

        public async Task<TEntity> GetById(Guid id, bool tracking = false)
        {
            var entity = await _entities.FindAsync(id);

            if (!tracking && entity != null)
                Context.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _entities.Update(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        protected DbContext Context
        {
            get
            {
                return _context as DbContext;
            }
        }

    }
}
