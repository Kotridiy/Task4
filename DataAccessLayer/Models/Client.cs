using DataModel;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class Client : IClient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ISoldProduct> BoughtProducts { get; set; }
    }
}