using PrimeNumber.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumber.Business.Interfaces
{
    public interface IPrimeNumberService
    {
        int GetPrimeNumber(int index);
        Task<PrimeNum> Add(PrimeNum primeNum);
    }
}
