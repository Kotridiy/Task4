using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SoldProduct> BoughtProducts { get; set; }
    }
}