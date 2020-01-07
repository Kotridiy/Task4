using DataModel;
using System;

namespace BusinessLogic.Csv
{
    public class CsvRecord : ICsvRecord
    {
        public DateTime Date { get; set; }
        public string Client { get; set; }
        public string Product { get; set; }
        public int Price { get; set; }
        public string Manager { get; set; }

        public override string ToString()
        {
            return $"{Date.Date}; {Client}; {Product}; {Price}";
        }
    }
}
