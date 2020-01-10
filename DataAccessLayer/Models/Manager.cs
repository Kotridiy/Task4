using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class Manager
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public IEnumerable<SoldProduct> SoldProducts { get; set; }
    }
}