using System.Collections.Generic;

namespace DataModel
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<SoldProductDTO> SoldProducts { get; set; }
    }
}
