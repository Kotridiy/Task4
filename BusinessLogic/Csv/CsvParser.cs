using CsvHelper;
using DataAccessLayer.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BusinessLogic.Csv
{
    class CsvParser
    {
        IDataUnitOfWork UnitOfWork { get; set; }

        public CsvParser(IDataUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public bool ReadCsvFile(string path, string managerName)
        {
            using (var reader = new StreamReader(path))
            {
                using (var csvReader = new CsvReader(reader))
                {
                    csvReader.Configuration.Delimiter = ";";
                    csvReader.Configuration.RegisterClassMap<CsvRecordMap>();
                    csvReader.Read();
                    csvReader.ReadHeader();
                    var products = new List<SoldProductDTO>();
                    while (csvReader.Read())
                    {
                        CsvRecord record;
                        try
                        {
                            record = csvReader.GetRecord<CsvRecord>();
                        }
                        catch (Exception)
                        {
                            UnitOfWork.RemoveRecords(products);
                            return false;
                        }

                        record.Manager = managerName;
                        products.Add(UnitOfWork.AddRecord(record));
                    }
                    UnitOfWork.Save();
                    return true;
                }
            }
        }
    }
}
