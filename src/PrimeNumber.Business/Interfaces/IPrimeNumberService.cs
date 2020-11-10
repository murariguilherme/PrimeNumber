using PrimeNumber.Business.Models;
using PrimeNumber.Business.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumber.Business.Interfaces
{
    public interface IPrimeNumberService
    {
        bool VerifyIsPrime(int number);
        int FindPrimeByIndex(int index);
        Task<PrimeNumViewModel> Add(int index);
        bool VerifyIfExistisOnDatabase(int index);
        Task<PrimeNum> GetByIndex(int index);
    }
}
