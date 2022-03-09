using GrupoCiencias.Intranet.Repository.Implementations.Data;
using GrupoCiencias.Intranet.Repository.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Repository.Implementations.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private DbSet<T> table = null;
        private readonly DataContext Context;

        public BaseRepository(DataContext context)
        {
            Context = context;
            table = context.Set<T>();
        }

        public async Task Delete(object id)
        {
            T existing = await table.FindAsync(id);
            table.Remove(existing);
        }

        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate) => await table.FirstOrDefaultAsync(predicate);

        public async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToListAsync();
        }

        public async Task<T> GetById(int id) => await table.FindAsync(id);

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await table.Where(predicate).ToListAsync();
        }

        public async Task Insert(T entity)
        {
            await table.AddAsync(entity);
        }

        public void Update(T entity, bool activarDeteccion = false)
        {
            table.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified; 
        }
    }
}
