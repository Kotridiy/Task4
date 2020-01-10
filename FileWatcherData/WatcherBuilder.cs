using FileWatcherData.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileWatcherData
{
    public static class WatcherBuilder
    {
        public static IWatcherUnitOfWork CreateUnitOfWork(string info = "")
        {
            var options = new DbContextOptionsBuilder<WatcherContext>().UseSqlServer(info).Options;
            WatcherContext context = new WatcherContext(options);
            IFileWatcherRepository repository = new WatcherRepository(context);
            return new WatcherUnitOfWork(repository);
        }
    }
}
