using DataModel;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class SoldProduct : ISoldProduct
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [NotMapped]
        public IClient Client { get; set; }
        [NotMapped]
        public IManager Manager { get; set; }
        [NotMapped]
        public IProduct Product { get; set; }
    }
}
