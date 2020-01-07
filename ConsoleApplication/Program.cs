using BusinessLogic;
using CsvHelper;
using System;
using System.Configuration;
using System.IO;

namespace ConsoleApplication
{
    partial class Program
    {
        const string FILE_PATH = @"D:\Сейф\С#\Tasks\MonitorTask\Materials\Monitor";

        static void Main(string[] args)
        {
            string monitorPath = ConfigurationManager.AppSettings.Get("monitor-folder");
            string readyPath = ConfigurationManager.AppSettings.Get("ready-folder");
            string watcherConnection = ConfigurationManager.AppSettings.Get("watcher-connection");
            string dataConnection = ConfigurationManager.AppSettings.Get("data-connection");

            FileLogic fileLogic = new FileLogic();  
            using (FileSystemWatcher watcher = new FileSystemWatcher(monitorPath, "*.csv"))
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
    }
}
