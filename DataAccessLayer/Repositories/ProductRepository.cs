using DataAccessLayer.Interfaces;
using DataModel;
using System;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    class ProductRepository : IGenericRepository<IProduct>
    {
        ApplicationContext Context { get; set; }

        public ProductRepository(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddAndSave(IProduct entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
        }

        public IProduct Get(string name)
        {
            return Context.Products.First(e => e.Name == name);
        }
    }
}
