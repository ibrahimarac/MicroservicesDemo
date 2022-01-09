using Contact.Application.Interfaces.Common;
using Contact.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Contact.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IContactDbContext _context;
        private readonly DbSet<TEntity> _entities;

        public Repository(IContactDbContext context)
        {
            _context = context;
            _entities = Context.Set<TEntity>();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            await _entities.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(Guid id)
        {
            var entity= await _entities.FindAsync(id);
            (_context as DbContext).Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            var items = await _entities.ToListAsync();
            return items;
        }

        public async Task<IEnumerable<TEntity>> GetByFilter(Expression<Func<TEntity, bool>> filter)
        {
            var items=await _entities.Where(filter).ToListAsync();
            return items;
        }

        public async Task<TEntity> GetById(Guid id)
        {
            var item= await _entities.FindAsync(id);
            return item;
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
