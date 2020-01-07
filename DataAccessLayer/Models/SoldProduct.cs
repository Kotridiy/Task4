using DataModel;
using System;

namespace DataAccessLayer.Models
{
    public class SoldProduct : ISoldProduct
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public IClient Client { get; set; }
        public IManager Manager { get; set; }
        public IProduct Product { get; set; }
    }
}
