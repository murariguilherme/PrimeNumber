using PrimeNumber.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumber.Business.Interfaces
{
    public interface IRepository<T> where T: Entity
    {
        Task Create(T obj);
        Task Delete(Guid id);
        Task Update(T obj);
        Task<T> Read(Guid id);
        Task<IEnumerable<T>> GetAll();
    }
}
