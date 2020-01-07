using DataAccessLayer.Interfaces;
using DataModel;
using System;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    class ManagerRepository : IGenericRepository<IManager>
    {
        ApplicationContext Context { get; set; }

        public ManagerRepository(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddAndSave(IManager entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
        }

        public IManager Get(string name)
        {
            return Context.Managers.First(e => e.Name == name);
        }
    }
}
