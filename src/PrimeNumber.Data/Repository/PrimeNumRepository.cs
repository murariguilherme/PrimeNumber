using Microsoft.EntityFrameworkCore;
using PrimeNumber.Business.Interfaces;
using PrimeNumber.Business.Models;
using PrimeNumber.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumber.Data.Repository
{
    public class PrimeNumRepository: Repository<PrimeNum>, IPrimeNumRepository
    {
        public PrimeNumRepository(PrimeNumberDbContext context): base(context) { }

        public Task<PrimeNum> GetByIndex(int index)
        {
            return DbSet.FirstOrDefaultAsync(p => p.Index == index);
        }

        public bool IndexExistsOnDatabase(int index)
        {
            return DbSet.Any(p => p.Index == index);
        }
    }
}
