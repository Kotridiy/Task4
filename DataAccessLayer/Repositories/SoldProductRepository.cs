using DataAccessLayer.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Repositories
{
    class SoldProductRepository : ISoldProductRepository
    {
        ApplicationContext Context { get; set; }

        public SoldProductRepository(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(ISoldProduct item)
        {
            Context.Add(item);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Delete(IEnumerable<ISoldProduct> items)
        {
            Context.RemoveRange(items);
        }
    }
}
