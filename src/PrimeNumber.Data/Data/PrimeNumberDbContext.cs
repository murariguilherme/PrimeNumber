using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using PrimeNumber.Business.Models;

namespace PrimeNumber.Data.Data
{
    public class PrimeNumberDbContext: DbContext
    {
        public PrimeNumberDbContext(DbContextOptions<PrimeNumberDbContext> options): base(options) { }

        public DbSet<PrimeNum> PrimeNums { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PrimeNumberDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
