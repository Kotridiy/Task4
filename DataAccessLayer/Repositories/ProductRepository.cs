using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Linq;
using System.Threading;

namespace DataAccessLayer.Repositories
{
    class ProductRepository : IGenericRepository<Product>
    {
        ApplicationContext Context { get; set; }
        ReaderWriterLockSlim _locker;

        public ProductRepository(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            _locker = new ReaderWriterLockSlim();
        }

        public void AddAndSave(Product entity)
        {
            Context.Add(entity); _locker.EnterWriteLock();
            try
            {
                Context.SaveChanges();
            }
            finally
            {
                _locker.ExitWriteLock();
            }
        }

        public Product Get(string name)
        {
            _locker.EnterReadLock();
            Product model;
            try
            {
                model = Context.Products.FirstOrDefault(e => e.Name == name);
            }
            finally
            {
                _locker.ExitReadLock();
            }
            return model;
        }
    }
}
