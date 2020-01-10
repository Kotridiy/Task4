using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataModel;
using System;
using System.Linq;
using System.Threading;

namespace DataAccessLayer.Repositories
{
    class ClientRepository : IGenericRepository<Client>
    {
        ApplicationContext Context { get; set; }
        ReaderWriterLockSlim _locker;

        public ClientRepository(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            _locker = new ReaderWriterLockSlim();
        }

        public void AddAndSave(Client entity)
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

        public Client Get(string name)
        {
            _locker.EnterReadLock();
            Client model;
            try
            {
                model = Context.Clients.FirstOrDefault(e => e.Name == name);
            }
            finally
            {
                _locker.ExitReadLock();
            }
            return model;
        }
    }
}
