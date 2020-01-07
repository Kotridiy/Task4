using DataModel;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface IDataUnitOfWork
    {
        ISoldProduct AddRecord(ICsvRecord record);
        void RemoveRecords(IEnumerable<ISoldProduct> items);
        void Save();
    }
}