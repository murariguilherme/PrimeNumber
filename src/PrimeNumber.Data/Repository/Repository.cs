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
    public abstract class Repository<T> : IRepository<T>, IUnitOfWork, IDisposable where T : Entity, new()
    {
        private readonly PrimeNumberDbContext _context;
        protected readonly DbSet<T> DbSet;

        protected Repository(PrimeNumberDbContext context)
        {
            this._context = context;
            DbSet = this._context.Set<T>();
        }
       
        public Task<int> Commit()
        {
            return _context.Commit();
        }

        public async Task Create(T obj)
        {
            await DbSet.AddAsync(obj);
            await this.Commit();
        }

        public async Task Delete(Guid id)
        {
            DbSet.Remove(new T { Id = id });
            await this.Commit();
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
            await this.Commit();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
