using SaltpayBank.Infrastructure.Data.Repositories;
using SaltpayBank.Seedwork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SaltpayBank.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EFContext _dbContext;

        public UnitOfWork(EFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IAsyncRepository<T> AsyncRepository<T>() where T : BaseEntity
        {
            return new RepositoryBase<T>(_dbContext);
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
