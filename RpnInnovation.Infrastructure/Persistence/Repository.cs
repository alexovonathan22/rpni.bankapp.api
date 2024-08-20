using RpnInnovation.Application.OtherInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpnInnovation.Infrastructure.Persistence
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public Repository()
        {
            
        }

        public Task<string> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
