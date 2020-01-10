using FileWatcherData.Interfaces;
using FileWatcherModel;
using System;
using System.Threading;

namespace FileWatcherData
{
    class WatcherRepository : IFileWatcherRepository
    {
        internal WatcherContext WatcherContext { get; private set; }
        ReaderWriterLockSlim _locker;

        public WatcherRepository(WatcherContext watcherContext)
        {
            WatcherContext = watcherContext ?? throw new ArgumentNullException(nameof(watcherContext));
            _locker = new ReaderWriterLockSlim();
        }

        public WatchFile Get(Guid guid)
        {
            _locker.EnterReadLock();
            WatchFile file;
            try
            {
                file = WatcherContext.Files.Find(guid);
            }
            finally
            {
                _locker.ExitReadLock();
            }
            return file;
        }

        public void Save()
        {
            _locker.EnterWriteLock();
            try
            {
                WatcherContext.SaveChanges();
            }
            finally
            {
                _locker.ExitWriteLock();
            }
        }

        public void Add(WatchFile file)
        {
            WatchFile innerFile = Get(file.Id);
            if (innerFile == null)
            {
                WatcherContext.Add(file);
            }
            else
            {
                WatcherContext.Update(innerFile);
            }
        }
    }
}
