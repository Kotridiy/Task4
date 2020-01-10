using FileWatcherModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FileWatcherData
{
    public class WatcherContext : DbContext
    {
        public DbSet<WatchFile> Files { get; set; }

        public WatcherContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=File_watcher;Trusted_Connection=True;");
        }
    }
}
