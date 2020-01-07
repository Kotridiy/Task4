using DataModel;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface ISoldProductRepository
    {
        void Add(ISoldProduct item);
        void Delete(IEnumerable<ISoldProduct> items);
        void Save();
    }
}
