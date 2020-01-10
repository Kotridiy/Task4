using System;

namespace FileWatcherData.Interfaces
{
    interface IFileWatcherRepository
    {
        WatchFile Get(Guid guid);
        void Add(WatchFile file);
        void Save();
    }
}
