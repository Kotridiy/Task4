using DataAccessLayer.Interfaces;
using DataModel;
using System;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    class ClientRepository : IGenericRepository<IClient>
    {
        ApplicationContext Context { get; set; }

        public ClientRepository(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddAndSave(IClient entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
        }

        public IClient Get(string name)
        {
            return Context.Clients.First(e => e.Name == name);
        }
    }
}
