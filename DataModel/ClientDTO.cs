using System.Collections.Generic;

namespace DataModel
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<SoldProductDTO> BoughtProducts { get; set; }
    }
}
