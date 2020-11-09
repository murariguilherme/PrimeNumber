using PrimeNumber.Business.Interfaces;
using PrimeNumber.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<PrimeNum> Add(PrimeNum primeNum)
        {
            if (VerifyIfExistisOnDatabase(primeNum.Index))
            {
                return await _primeNumberRepository.GetByIndex(primeNum.Index);
            }

            await _primeNumberRepository.Create(primeNum);
            //await _primeNumberRepository.UnitOfWork.Commit();

            return primeNum;
        }

        public bool VerifyIfExistisOnDatabase(int index)
        {
            return _primeNumberRepository.IndexExistsOnDatabase(index);
        }
    }
}
