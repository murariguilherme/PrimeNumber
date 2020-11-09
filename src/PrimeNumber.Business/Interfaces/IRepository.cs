using PrimeNumber.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumber.Business.Interfaces
{
    public interface IRepository<T> where T: Entity
    {
        IUnitOfWork UnitOfWork { get; }
        Task Create(T obj);
        void Delete(Guid id);
        Task Update(T obj);
        Task<T> Read(Guid id);
        Task<IEnumerable<T>> GetAll();
    }
}
