using PrimeNumber.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeNumber.Business.Services
{
    public class PrimeNumberService : IPrimeNumberService
    {
        private readonly IPrimeNumRepository _primeNumberRepository;

        public PrimeNumberService(IPrimeNumRepository primeNumberRepository)
        {
            _primeNumberRepository = primeNumberRepository;
        }
        public int GetPrimeNumber(int index)
        {
            throw new NotImplementedException();
        }
    }
}
