using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ServiceApplication
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
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
            }
        }

        protected override void OnStop()
        {
        }
    }
}
