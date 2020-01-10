using CsvHelper.Configuration;
using DataModel;

namespace BusinessLogic.Csv
{
    sealed class CsvRecordMap : ClassMap<CsvRecord>
    {
        public CsvRecordMap()
        {
            Map(m => m.Date);
            Map(m => m.Client);
            Map(m => m.Product);
            Map(m => m.Price);
        }
    }
}
