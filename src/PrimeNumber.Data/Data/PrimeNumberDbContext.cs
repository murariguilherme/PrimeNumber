using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeNumber.Data.Data
{
    public class PrimeNumberDbContext: DbContext
    {
        public PrimeNumberDbContext(DbContextOptions<PrimeNumberDbContext> options): base(options) { }
    }
}
