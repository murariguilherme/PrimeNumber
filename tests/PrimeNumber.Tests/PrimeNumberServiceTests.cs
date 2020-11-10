using Moq;
using Moq.AutoMock;
using PrimeNumber.Business.Interfaces;
using PrimeNumber.Business.Models;
using PrimeNumber.Business.Services;
using PrimeNumber.Data.Data;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PrimeNumber.Tests
{
    public class PrimeNumberServiceTests
    {
        [Fact]
        public async void PrimeNumberServiceTests_AddNewRecordToDatabase_MustVerifyIfExistsOnDatabase()
        {
            var primeNum = new PrimeNum() { Index = 5, PrimeValue = 7 };
            var mocker = new AutoMocker();
            
            var service = mocker.CreateInstance<PrimeNumberService>();

            mocker.GetMock<IPrimeNumRepository>().Setup(r => r.UnitOfWork.Commit()).Returns(Task.FromResult(1));

            await service.Add(primeNum.Index);

            mocker.GetMock<IPrimeNumRepository>().Verify(r => r.IndexExistsOnDatabase(primeNum.Index), Times.Once);
        }

        [Fact]
        public async void PrimeNumberServiceTests_AddNewRecordToDatabase_ExistsOnDatabase_MustGetFromDatabase()
        {
            var primeNum = new PrimeNum() { Index = 5, PrimeValue = 7 };
            var mocker = new AutoMocker();
            var service = mocker.CreateInstance<PrimeNumberService>();
                      
            mocker.GetMock<IPrimeNumRepository>().Setup(r => r.IndexExistsOnDatabase(primeNum.Index)).Returns(true);
            mocker.GetMock<IPrimeNumRepository>().Setup(r => r.GetByIndex(primeNum.Index)).Returns(Task.FromResult(new PrimeNum()));

            await service.Add(primeNum.Index);
            mocker.GetMock<IPrimeNumRepository>().Verify(r => r.GetByIndex(primeNum.Index), Times.Once);
        }

        [Fact]
        public async void PrimeNumberServiceTests_AddNewRecordToDatabase_NotExistsOnDatabase_MustInsert()
        {
            var primeNum = new PrimeNum() { Index = 5, PrimeValue = 7 };
            var mocker = new AutoMocker();
            var service = mocker.CreateInstance<PrimeNumberService>();

            mocker.GetMock<IPrimeNumRepository>().Setup(r => r.IndexExistsOnDatabase(primeNum.Index)).Returns(false);
            mocker.GetMock<IPrimeNumRepository>().Setup(r => r.UnitOfWork.Commit()).Returns(Task.FromResult(1));
            mocker.GetMock<IPrimeNumRepository>().Setup(r => r.Create(primeNum)).Returns(Task.FromResult(primeNum));

            await service.Add(primeNum.Index);

            mocker.GetMock<IPrimeNumRepository>().Verify(r => r.Create(It.IsAny<PrimeNum>()), Times.Once);
            mocker.GetMock<IPrimeNumRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact]
        public void PrimeNumberServiceTests_VerifyIfIsPrime_ResultIsNotPrime()
        {            
            var mocker = new AutoMocker();
            var service = mocker.CreateInstance<PrimeNumberService>();

            Assert.False(service.VerifyIsPrime(1));            
            Assert.False(service.VerifyIsPrime(4));
            Assert.False(service.VerifyIsPrime(8));
            Assert.False(service.VerifyIsPrime(10));
            Assert.False(service.VerifyIsPrime(15));
        }

        [Fact]
        public void PrimeNumberServiceTests_VerifyIfIsPrime_ResultIsPrime()
        {            
            var mocker = new AutoMocker();
            var service = mocker.CreateInstance<PrimeNumberService>();

            Assert.True(service.VerifyIsPrime(3));
            Assert.True(service.VerifyIsPrime(7));
            Assert.True(service.VerifyIsPrime(13));
            Assert.True(service.VerifyIsPrime(17));
            Assert.True(service.VerifyIsPrime(23));
        }

        [Theory]
        [InlineData(5, 7)]
        [InlineData(7, 13)]
        [InlineData(26657, 308137)]
        public void PrimeNumberServiceTests_GetPrimeByIndex(int index, int result)
        {
            var mocker = new AutoMocker();
            var service = mocker.CreateInstance<PrimeNumberService>();

            Assert.Equal(result, service.FindPrimeByIndex(index));
        }
    }
}
