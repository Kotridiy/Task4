using DataModel;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface IDataUnitOfWork
    {
        SoldProductDTO AddRecord(CsvRecord record);
        void RemoveRecords(IEnumerable<SoldProductDTO> items);
        void Save();
    }
}