using DataAccessLayer.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    class DataUnitOfWork : IDataUnitOfWork
    {
        IGenericRepository<IClient> ClientRepository { get; set; }
        IGenericRepository<IProduct> ProductRepository { get; set; }
        IGenericRepository<IManager> ManagerRepository { get; set; }
        ISoldProductRepository SoldProductRepository { get; set; }

        public DataUnitOfWork(
            IGenericRepository<IClient> clientRepository,
            IGenericRepository<IProduct> productRepository,
            IGenericRepository<IManager> managerRepository,
            ISoldProductRepository soldProductRepository)
        {
            ClientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
            ProductRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            ManagerRepository = managerRepository ?? throw new ArgumentNullException(nameof(managerRepository));
            SoldProductRepository = soldProductRepository ?? throw new ArgumentNullException(nameof(soldProductRepository));
        }

        //TODO
        public ISoldProduct AddRecord(ICsvRecord record)
        {
            throw new NotImplementedException();
        }

        public void RemoveRecords(IEnumerable<ISoldProduct> items)
        {
            SoldProductRepository.Delete(items);
        }

        public void Save()
        {
            SoldProductRepository.Save();
        }
    }
}
