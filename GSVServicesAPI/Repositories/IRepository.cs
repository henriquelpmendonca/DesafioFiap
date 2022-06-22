using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSVServicesAPI.Repositories
{
    public interface IRepository<T>
    {
        Task<int> Create(T Model);
        Task<int> Delete(int Id);
        Task<int> Update(T Model);
        Task<T> GetById(int Id);
        Task<List<T>> ListAll();
    }
}
