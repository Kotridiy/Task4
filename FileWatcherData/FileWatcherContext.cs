using FileWatcherModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FileWatcherData
{
    public class FileWatcherContext : DbContext
    {
        public DbSet<WatchFile> Files { get; set; }

        public FileWatcherContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=File_watcher;Trusted_Connection=True;");
        }
    }
}
