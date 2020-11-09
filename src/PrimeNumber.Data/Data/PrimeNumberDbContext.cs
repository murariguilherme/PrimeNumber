using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using PrimeNumber.Business.Models;
using PrimeNumber.Business.Interfaces;
using System.Threading.Tasks;

namespace PrimeNumber.Data.Data
{
    public class PrimeNumberDbContext: DbContext, IUnitOfWork
    {
        public PrimeNumberDbContext(DbContextOptions<PrimeNumberDbContext> options): base(options) { }

        public DbSet<PrimeNum> PrimeNums { get; set; }

        public async Task<int> Commit()
        {
            return await this.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PrimeNumberDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
