using GrupoCiencias.Intranet.Repository.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Repository.Implementations.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public async Task Delete(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity, bool activarDeteccion = false)
        {
            throw new NotImplementedException();
        }
    }
}
