using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;

namespace DataAccessLayer.Repositories
{
    class SoldProductRepository : ISoldProductRepository
    {
        ApplicationContext Context { get; set; }
        ReaderWriterLockSlim _locker;

        public SoldProductRepository(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            _locker = new ReaderWriterLockSlim();
        }

        public void Add(SoldProduct item)
        {
            Context.Update(item);
        }

        public void Save()
        {
            _locker.EnterWriteLock();
            try
            {
                Context.SaveChanges();
            }
            finally
            {
                _locker.ExitWriteLock();
            }
        }

        public void Delete(IEnumerable<SoldProduct> items)
        {
            Context.RemoveRange(items);
        }

        public void DetachModels(SoldProduct item)
        {
            Context.Entry(item.Client).State = EntityState.Unchanged;
            Context.Entry(item.Manager).State = EntityState.Unchanged;
            Context.Entry(item.Product).State = EntityState.Unchanged;
        }
    }
}
