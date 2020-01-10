using DataAccessLayer;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FileWatcherData
{
    public static class DataAccessBuilder
    {
        public static IDataUnitOfWork CreateUnitOfWork(string info = "")
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>().UseSqlServer(info).Options;

            ApplicationContext context = new ApplicationContext(options);
            var clientRepo = new ClientRepository(context);
            var productRepo = new ProductRepository(context);
            var managerRepo = new ManagerRepository(context);

            ApplicationContext soldProductContext = new ApplicationContext(options);
            var soldProductRepo = new SoldProductRepository(soldProductContext);

            return new DataUnitOfWork(clientRepo, productRepo, managerRepo, soldProductRepo);
        }
    }
}
