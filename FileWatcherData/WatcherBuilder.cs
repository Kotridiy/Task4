using FileWatcherData.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileWatcherData
{
    public static class WatcherBuilder
    {
        public static IWatcherUnitOfWork CreateUnitOfWork(string info = "")
        {
            WatcherContext context = new WatcherContext();
            IFileWatcherRepository repository = new WatcherRepository(context);
            return new WatcherUnitOfWork(repository);
        }
    }
}
