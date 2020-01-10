using DataAccessLayer.Models;
using DataModel;
using System.Linq;

namespace DataAccessLayer
{
    public static class DataMapper
    {
        public static SoldProduct ToSoldProduct(SoldProductDTO model)
        {
            return model == null ? null : new SoldProduct()
            {
                Client = ToClient(model.Client),
                Manager = ToManager(model.Manager),
                Product = ToProduct(model.Product),
                Date = model.Date
            };
        } 

        public static Manager ToManager (ManagerDTO model)
        {
            return model == null ? null : new Manager
            {
                Id = model.Id,
                Name = model.Name,
                SoldProducts = model.SoldProducts?.Select(e => ToSoldProduct(e))
            };
        } 

        public static Product ToProduct (ProductDTO model)
        {
            return model == null ? null : new Product
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                SoldProducts = model.SoldProducts?.Select(e => ToSoldProduct(e))
            };
        } 

        public static Client ToClient (ClientDTO model)
        {
            return model == null ? null : new Client
            {
                Id = model.Id,
                Name = model.Name,
                BoughtProducts = model.BoughtProducts?.Select(e => ToSoldProduct(e))
            };
        }
        
        public static SoldProductDTO ToSoldProductDTO(SoldProduct model)
        {
            return model == null ? null : new SoldProductDTO()
            {
                Id = model.Id,
                Client = ToClientDTO(model.Client),
                Manager = ToManagerDTO(model.Manager),
                Product = ToProductDTO(model.Product),
                Date = model.Date
            };
        } 

        public static ManagerDTO ToManagerDTO (Manager model)
        {
            return model == null ? null : new ManagerDTO
            {
                Id = model.Id,
                Name = model.Name,
                SoldProducts = model.SoldProducts?.Select(e => ToSoldProductDTO(e))
            };
        } 

        public static ProductDTO ToProductDTO (Product model)
        {
            return model == null ? null : new ProductDTO
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                SoldProducts = model.SoldProducts?.Select(e => ToSoldProductDTO(e))
            };
        } 

        public static ClientDTO ToClientDTO (Client model)
        {
            return model == null ? null : new ClientDTO
            {
                Id = model.Id,
                Name = model.Name,
                BoughtProducts = model.BoughtProducts?.Select(e => ToSoldProductDTO(e))
            };
        }
    }
}
