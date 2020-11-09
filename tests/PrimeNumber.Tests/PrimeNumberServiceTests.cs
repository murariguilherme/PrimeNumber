using Moq;
using Moq.AutoMock;
using PrimeNumber.Business.Interfaces;
using PrimeNumber.Business.Models;
using PrimeNumber.Business.Services;
using System;
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

            await service.Add(primeNum);

            mocker.GetMock<IPrimeNumRepository>().Verify(r => r.IndexExistsOnDatabase(primeNum.Index), Times.Once); ;
        }

        [Fact]
        public async void PrimeNumberServiceTests_AddNewRecordToDatabase_ExistsOnDatabase_MustGetFromDatabase()
        {
            var primeNum = new PrimeNum() { Index = 5, PrimeValue = 7 };
            var mocker = new AutoMocker();
            var service = mocker.CreateInstance<PrimeNumberService>();

            mocker.GetMock<IPrimeNumRepository>().Setup(r => r.IndexExistsOnDatabase(primeNum.Index)).Returns(true);

            await service.Add(primeNum);
            
            mocker.GetMock<IPrimeNumRepository>().Verify(r => r.GetByIndex(primeNum.Index), Times.Once); ;
        }

        [Fact]
        public async void PrimeNumberServiceTests_AddNewRecordToDatabase_NotExistsOnDatabase_MustInsert()
        {
            var primeNum = new PrimeNum() { Index = 5, PrimeValue = 7 };
            var mocker = new AutoMocker();
            var service = mocker.CreateInstance<PrimeNumberService>();

            mocker.GetMock<IPrimeNumRepository>().Setup(r => r.IndexExistsOnDatabase(primeNum.Index)).Returns(false);

            await service.Add(primeNum);

            mocker.GetMock<IPrimeNumRepository>().Verify(r => r.Create(primeNum), Times.Once);
            //mocker.GetMock<IPrimeNumRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }
    }
}
