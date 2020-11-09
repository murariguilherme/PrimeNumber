using PrimeNumber.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumber.Business.Interfaces
{
    public interface IPrimeNumRepository : IRepository<PrimeNum>
    {
        bool IndexExistsOnDatabase(int index);
        Task<PrimeNum> GetByIndex(int index);
    }
}
