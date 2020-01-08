using DataModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        [NotMapped]
        public ICollection<ISoldProduct> SoldProducts { get; set; }
    }
}