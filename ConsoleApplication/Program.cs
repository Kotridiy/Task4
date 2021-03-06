﻿using BusinessLogic;
using CsvHelper;
using System;
using System.Configuration;
using System.IO;

namespace ConsoleApplication
{
    partial class Program
    {
        static void Main(string[] args)
        {
            string monitorPath = ConfigurationManager.AppSettings.Get("monitor-folder");
            string readyPath = ConfigurationManager.AppSettings.Get("ready-folder");
            string watcherConnection = ConfigurationManager.AppSettings.Get("watcher-connection");
            string dataConnection = ConfigurationManager.AppSettings.Get("data-connection");

            FileProcessor fileLogic = new FileProcessor();  
            using (FileSystemWatcher watcher = new FileSystemWatcher(monitorPath, "*.csv"))
            {
                watcher.Created += fileLogic.OnFileCreate;
                watcher.EnableRaisingEvents = true;

                Console.WriteLine("Press q to exit");
                while (Console.Read() != 'q') { }
            }
        }
    }
}
