using System;
using System.Collections.Generic;
using System.Text;

namespace Data.UnitOfWord
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        OnlineShopDbContext GetDBContext();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlineShopDbContext _dbContext;
        private bool _disposed = false;
        public UnitOfWork(OnlineShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public OnlineShopDbContext GetDBContext()
        {
            return _dbContext;
        }
        public void Commit()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }

            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing && _dbContext != null)
            {
                _dbContext.Dispose();
            }

            _disposed = true;
        }
    }
}
