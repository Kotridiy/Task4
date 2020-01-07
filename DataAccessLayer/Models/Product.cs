using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ICollection<SoldProduct> SoldProducts { get; set; }
    }
}