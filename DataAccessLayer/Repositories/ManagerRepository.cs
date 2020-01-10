using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Linq;
using System.Threading;

namespace DataAccessLayer.Repositories
{
    class ManagerRepository : IGenericRepository<Manager>
    {
        ApplicationContext Context { get; set; }
        ReaderWriterLockSlim _locker;

        public ManagerRepository(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            _locker = new ReaderWriterLockSlim();
        }

        public void AddAndSave(Manager entity)
        {
            Context.Add(entity);
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

        public Manager Get(string name)
        {
            _locker.EnterReadLock();
            Manager model;
            try
            {
                model = Context.Managers.FirstOrDefault(e => e.Name == name);
            }
            finally
            {
                _locker.ExitReadLock();
            }
            return model;
        }
    }
}
