using Microsoft.EntityFrameworkCore;
using PrimeNumber.Business.Interfaces;
using PrimeNumber.Business.Models;
using PrimeNumber.Data.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumber.Data.Repository
{
    public abstract class Repository<T> : IRepository<T>, IDisposable where T : Entity, new()
    {
        protected readonly PrimeNumberDbContext _context;
        protected readonly DbSet<T> DbSet;

        public IUnitOfWork UnitOfWork => _context;

        protected Repository(PrimeNumberDbContext context)
        {
            this._context = context;
            DbSet = this._context.Set<T>();
        }      

        public async Task Create(T obj)
        {
            await DbSet.AddAsync(obj);
        }

        public void Delete(Guid id)
        {
            DbSet.Remove(new T { Id = id });
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T> Read(Guid id)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Update(T obj)
        {
            DbSet.Update(obj);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
