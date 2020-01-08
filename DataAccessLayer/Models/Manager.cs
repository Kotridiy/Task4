using DataModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class Manager : IManager
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public ICollection<ISoldProduct> SoldProducts { get; set; }
    }
}