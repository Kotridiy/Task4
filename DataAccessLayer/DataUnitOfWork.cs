using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
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
            var soldProduct = new SoldProduct()
            {
                Client = GetClient(record.Client),
                Product = GetProduct(record.Product, record.Price),
                Manager = GetManager(record.Manager),
                Date = record.Date
            };
            SoldProductRepository.Add(soldProduct);
            return soldProduct;
        }

        private IManager GetManager(string name)
        {
            var manager = ManagerRepository.Get(name);
            if (manager == null)
            {
                manager = new Manager() { Name = name };
                ManagerRepository.AddAndSave(manager);
            }
            return manager;
        }

        private IProduct GetProduct(string name, int price)
        {
            var product = ProductRepository.Get(name);
            if (product == null)
            {
                product = new Product() { Name = name, Price = price };
                ProductRepository.AddAndSave(product);
            }
            return product;
        }

        private IClient GetClient(string name)
        {
            var client = ClientRepository.Get(name);
            if (client == null)
            {
                client = new Client() { Name = name };
                ClientRepository.AddAndSave(client);
            }
            return client;
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
