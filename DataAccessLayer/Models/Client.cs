using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public IEnumerable<SoldProduct> BoughtProducts { get; set; }
    }
}