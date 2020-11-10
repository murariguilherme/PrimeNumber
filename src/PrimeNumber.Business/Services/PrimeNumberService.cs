using PrimeNumber.Business.Interfaces;
using PrimeNumber.Business.Models;
using PrimeNumber.Business.ViewModel;
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

        public int FindPrimeByIndex(int index)
        {
            var primeNumberCount = 1;
            var number = 1;

            while (primeNumberCount != index)
            {
                if (VerifyIsPrime(number))
                {
                    primeNumberCount += 1;
                    if (primeNumberCount == index) continue;
                }
                                   
                number += 1;
            }

            return number;
        }

        public bool VerifyIsPrime(int number)
        {
            if (number == 1) 
                return false;
            if (number == 2) 
                return true;

            if (number % 2 == 0) return false;

            for (int i = 3; i < number; i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }        

        public async Task<PrimeNumViewModel> Add(int index)
        {
            if (VerifyIfExistisOnDatabase(index))
            {
                var primeValueDb = await GetByIndex(index);

                return new PrimeNumViewModel() { Index = primeValueDb.Index, PrimeValue = primeValueDb.PrimeValue };
            }

            var valueIndex = FindPrimeByIndex(index);

            var primeInstance = new PrimeNum() { Index = index, PrimeValue = valueIndex };

            await _primeNumberRepository.Create(primeInstance);
            await _primeNumberRepository.UnitOfWork.Commit();

            var pnViewModel = new PrimeNumViewModel() { Index = primeInstance.Index, PrimeValue = primeInstance.PrimeValue };

            return pnViewModel;
        }

        public bool VerifyIfExistisOnDatabase(int index)
        {
            return _primeNumberRepository.IndexExistsOnDatabase(index);
        }

        public async Task<PrimeNum> GetByIndex(int index)
        {
            return await _primeNumberRepository.GetByIndex(index);
        }
    }
}
