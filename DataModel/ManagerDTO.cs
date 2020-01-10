using System.Collections.Generic;

namespace DataModel
{
    public class ManagerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<SoldProductDTO> SoldProducts { get; set; }
    }
}
