using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    class DataUnitOfWork : IDataUnitOfWork
    {
        IGenericRepository<Client> ClientRepository { get; set; }
        IGenericRepository<Product> ProductRepository { get; set; }
        IGenericRepository<Manager> ManagerRepository { get; set; }
        ISoldProductRepository SoldProductRepository { get; set; }
        object _sync = new object();

        public DataUnitOfWork(
            IGenericRepository<Client> clientRepository,
            IGenericRepository<Product> productRepository,
            IGenericRepository<Manager> managerRepository,
            ISoldProductRepository soldProductRepository)
        {
            ClientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
            ProductRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            ManagerRepository = managerRepository ?? throw new ArgumentNullException(nameof(managerRepository));
            SoldProductRepository = soldProductRepository ?? throw new ArgumentNullException(nameof(soldProductRepository));
        }

        public SoldProductDTO AddRecord(CsvRecord record)
        {
            SoldProduct soldProduct;
            lock (_sync)
            {
                soldProduct = new SoldProduct()
                {
                    Client = GetClient(record.Client),
                    Product = GetProduct(record.Product, record.Price),
                    Manager = GetManager(record.Manager),
                    Date = record.Date
                };
                SoldProductRepository.Add(soldProduct);
                //(SoldProductRepository as SoldProductRepository)?.DetachModels(soldProduct);
            }
            return DataMapper.ToSoldProductDTO(soldProduct);
        }

        private Manager GetManager(string name)
        {
            var manager = ManagerRepository.Get(name);
            if (manager == null)
            {
                manager = new Manager() { Name = name };
                ManagerRepository.AddAndSave(manager);
            }
            return manager;
        }

        private Product GetProduct(string name, int price)
        {
            var product = ProductRepository.Get(name);
            if (product == null)
            {
                product = new Product() { Name = name, Price = price };
                ProductRepository.AddAndSave(product);
            }
            return product;
        }

        private Client GetClient(string name)
        {
            var client = ClientRepository.Get(name);
            if (client == null)
            {
                client = new Client() { Name = name };
                ClientRepository.AddAndSave(client);
            }
            return client;
        }

        public void RemoveRecords(IEnumerable<SoldProductDTO> items)
        {
            lock (_sync)
            {
                SoldProductRepository.Delete(items.Select(e => DataMapper.ToSoldProduct(e)));
            }
        }

        public void Save()
        {
            lock (_sync)
            {
                SoldProductRepository.Save();
            }
        }
    }
}
