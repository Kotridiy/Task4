using DataAccessLayer.Models;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface ISoldProductRepository
    {
        void Add(SoldProduct item);
        void Delete(IEnumerable<SoldProduct> items);
        void Save();
    }
}
