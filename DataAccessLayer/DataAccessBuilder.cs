using DataAccessLayer;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;

namespace FileWatcherData
{
    public static class DataAccessBuilder
    {
        public static IDataUnitOfWork CreateUnitOfWork(string info = "")
        {
            ApplicationContext context = new ApplicationContext();
            var clientRepo = new ClientRepository(context);
            var productRepo = new ProductRepository(context);
            var managerRepo = new ManagerRepository(context);

            ApplicationContext soldProductContext = new ApplicationContext();
            var soldProductRepo = new SoldProductRepository(soldProductContext);

            return new DataUnitOfWork(clientRepo, productRepo, managerRepo, soldProductRepo);
        }
    }
}
