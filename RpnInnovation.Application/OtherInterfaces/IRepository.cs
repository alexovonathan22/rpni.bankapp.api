using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpnInnovation.Application.OtherInterfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        Task<string> AddAsync(T entity);
        Task<string> UpdateAsync(T entity);
        //Task<string> DeleteAsync(long id);
    }
}
