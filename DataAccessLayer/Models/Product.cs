using DataModel;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ICollection<ISoldProduct> SoldProducts { get; set; }
    }
}