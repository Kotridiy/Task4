using DataModel;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class Manager : IManager
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ISoldProduct> SoldProducts { get; set; }
    }
}