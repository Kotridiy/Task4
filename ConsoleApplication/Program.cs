using BusinessLogic;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApplication
{
    class Program
    {
        const string FILE_PATH = @"D:\Сейф\С#\Tasks\MonitorTask\Materials\Monitor";

        static void Main(string[] args)
        {
            FileLogic fileLogic = new FileLogic();  
            using (FileSystemWatcher watcher = new FileSystemWatcher(FILE_PATH, "*.csv"))
            {
                watcher.Created += fileLogic.OnFileCreate;
                watcher.EnableRaisingEvents = true;

                Console.WriteLine("Press q to exit");
                while (Console.Read() != 'q') { }
            }
            
        }

        /*private static void On_Create(object sender, FileSystemEventArgs e)
        {
            FileInfo info = new FileInfo(e.FullPath);
            var hash = GetFileHash(info);
            Console.WriteLine(ReadCsv(info.FullName));
            Console.WriteLine(new Guid(hash));
        }*/

        static CsvRecord ReadCsv(string path)
        {
            CsvReader csvReader = new CsvReader(new StreamReader(path));
            csvReader.Configuration.Delimiter = ";";
            csvReader.Configuration.RegisterClassMap<CsvRecordMap>();
            csvReader.Read();
            return csvReader.GetRecord<CsvRecord>();
        }

        class CsvRecord
        {
            public DateTime Date { get; set; }
            public string Client { get; set; }
            public string Product { get; set; }
            public int Price { get; set; }

            public override string ToString()
            {
                return $"{Date.Date}; {Client}; {Product}; {Price}";
            }
        }

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
}
