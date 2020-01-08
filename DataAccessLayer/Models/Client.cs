using DataModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class Client : IClient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public ICollection<ISoldProduct> BoughtProducts { get; set; }
    }
}