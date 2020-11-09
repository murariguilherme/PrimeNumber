using PrimeNumber.Business.Interfaces;
using PrimeNumber.Business.Models;
using PrimeNumber.Data.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeNumber.Data.Repository
{
    public class PrimeNumRepository: Repository<PrimeNum>, IPrimeNumRepository
    {
        public PrimeNumRepository(PrimeNumberDbContext context): base(context) { }
    }
}
