using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumber.Business.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> Commit();
    }
}
