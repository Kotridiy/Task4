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
            FileWatcherContext context = new FileWatcherContext();
            IFileWatcherRepository repository = new FileWatcherRepository(context);
            return new WatcherUnitOfWork(repository);
        }
    }
}
