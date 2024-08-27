using RpnInnovation.Application.OtherInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpnInnovation.Infrastructure.Persistence
{
    /// <summary>
    /// Get data from db source
    /// </summary>
    public class ReadRepository<T> : IReadRepository<T> where T : class
    {
       
        public Task<List<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
