using PrimeNumber.Business.Models;
using PrimeNumber.Data.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeNumber.Data.Repository
{
    public class RepositoryPrimeNum: Repository<PrimeNum>
    {
        public RepositoryPrimeNum(PrimeNumberDbContext context): base(context) { }
    }
}
